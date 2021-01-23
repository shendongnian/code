    internal class HeaderFooterPaginator<THeaderModel, TFooterModel> : DynamicDocumentPaginator where THeaderModel : PageNumberModel, new() where TFooterModel : PageNumberModel, new()
    {
        private readonly double _footerHeight;
        private readonly DataTemplate _footerTemplate;
        private readonly double _headerHeight;
        private readonly DataTemplate _headerTemplate;
        private Size _newPageSize;
        private Size _originalPageSize;
        private readonly DynamicDocumentPaginator _originalPaginator;
        private readonly int _pageNumberOffset;
        private readonly FlowDocument _paginatorSource;
        private const double HeaderAndFooterMarginHeight = 5;
        private const double HeaderAndFooterMarginWidth = 10;
    
        public HeaderFooterPaginator(int pageNumberOffset, FlowDocument document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("document");
            }
    
            _paginatorSource = document;
    
            if (_paginatorSource == null)
            {
                throw new InvalidOperationException("Could not create a clone of the document being paginated.");
            }
    
            _originalPaginator = ((IDocumentPaginatorSource) _paginatorSource).DocumentPaginator as DynamicDocumentPaginator;
    
            if (_originalPaginator == null)
            {
                throw new InvalidOperationException("The paginator must be a DynamicDocumentPaginator.");
            }
    
            _headerTemplate = GetModelDataTemplate(typeof (THeaderModel));
            _footerTemplate = GetModelDataTemplate(typeof (TFooterModel));
    
            var headerSize = GetModelContentSize(new THeaderModel { PageNumber = int.MaxValue }, _headerTemplate, _originalPaginator.PageSize);
            var footerSize = GetModelContentSize(new TFooterModel { PageNumber = int.MaxValue }, _footerTemplate, _originalPaginator.PageSize);
    
            _headerHeight = double.IsInfinity(headerSize.Height) ? 0 : headerSize.Height;
            _footerHeight = double.IsInfinity(footerSize.Height) ? 0 : footerSize.Height;
    
            _pageNumberOffset = pageNumberOffset;
    
            SetPageSize(new Size(document.PageWidth, document.PageHeight));
        }
    
        private void AddHeaderOrFooterToContainerAsync<THeaderOrFooter>(ContainerVisual container, double areaWidth, double areaHeight, Vector areaOffset, FrameworkTemplate template, int displayPageNumber)  where THeaderOrFooter : PageNumberModel, new()
        {
            if (template == null)
            {
                return;
            }
            var visual = GetModelContent(new THeaderOrFooter { PageNumber = displayPageNumber }, template);
    
            if (visual != null)
            {
                Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() =>
                {
                    visual.Measure(_originalPageSize);
                    visual.Arrange(new Rect(0, 0, areaWidth, areaHeight));
                    visual.UpdateLayout();
    
                    var headerContainer = new ContainerVisual { Offset = areaOffset };
                    headerContainer.Children.Add(visual);
                    container.Children.Add(headerContainer);
                }));
            }
        }
    
        public override void ComputePageCount()
        {
            _originalPaginator.ComputePageCount();
        }
    
        private static void FlushDispatcher()
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.ApplicationIdle, new DispatcherOperationCallback(delegate { return null; }), null);
        }
    
        private static FrameworkElement GetModelContent(object dataModel, FrameworkTemplate modelTemplate)
        {
            if (modelTemplate == null)
            {
                return null;
            }
    
            var content = modelTemplate.LoadContent() as FrameworkElement;
            if (content == null)
            {
                return null;
            }
    
            content.DataContext = dataModel;
    
            return content;
        }
    
        private static Size GetModelContentSize(object dataModel, FrameworkTemplate modelTemplate, Size availableSize)
        {
            var content = GetModelContent(dataModel, modelTemplate);
            if (content == null)
            {
                return Size.Empty;
            }
    
            FlushDispatcher();
            content.Measure(availableSize);
            return content.DesiredSize;
        }
    
        private DataTemplate GetModelDataTemplate(Type modelType)
        {
            var key = new DataTemplateKey(modelType);
            return _paginatorSource.TryFindResource(key) as DataTemplate;
        }
    
        public override ContentPosition GetObjectPosition(object value)
        {
            return _originalPaginator.GetObjectPosition(value);
        }
    
        public override DocumentPage GetPage(int pageNumber)
        {
            if (!_originalPaginator.IsPageCountValid)
            {
                ComputePageCount();
            }
    
            var originalPage = _originalPaginator.GetPage(pageNumber);
    
            var newPage = new ContainerVisual();
    
            var displayPageNumber = _pageNumberOffset + pageNumber;
            var internalWidth = _originalPageSize.Width - 2*HeaderAndFooterMarginWidth;
            AddHeaderOrFooterToContainerAsync<THeaderModel>(newPage, internalWidth, _headerHeight, new Vector(HeaderAndFooterMarginWidth, HeaderAndFooterMarginHeight), _headerTemplate, displayPageNumber);
    
            var smallerPage = new ContainerVisual();
            smallerPage.Children.Add(originalPage.Visual);
            smallerPage.Offset = new Vector(HeaderAndFooterMarginWidth, HeaderAndFooterMarginHeight + _headerHeight);
            newPage.Children.Add(smallerPage);
    
            AddHeaderOrFooterToContainerAsync<TFooterModel>(newPage, internalWidth, _footerHeight, new Vector(HeaderAndFooterMarginWidth, _originalPageSize.Height - HeaderAndFooterMarginHeight - _footerHeight), _footerTemplate, displayPageNumber);
    
            return new DocumentPage(newPage, _originalPageSize, originalPage.BleedBox, originalPage.ContentBox);
        }
    
        public override int GetPageNumber(ContentPosition contentPosition)
        {
            return _originalPaginator.GetPageNumber(contentPosition);
        }
    
        public override ContentPosition GetPagePosition(DocumentPage page)
        {
            return _originalPaginator.GetPagePosition(page);
        }
    
        private void SetPageSize(Size pageSize)
        {
            _originalPageSize = pageSize;
    
            // Decrease the available page size by the height of the header and footer. The page is offset by the header height later on.
            var sizeRect = new Rect(pageSize);
            sizeRect.Inflate(-HeaderAndFooterMarginWidth, -(HeaderAndFooterMarginHeight + _footerHeight/2 + _headerHeight/2));
    
            _originalPaginator.PageSize = _newPageSize = sizeRect.Size;
    
            // Change page size of the document to the size of the content area
            _paginatorSource.PageHeight = _newPageSize.Height;
            _paginatorSource.PageWidth = _newPageSize.Width;
        }
    
        public override bool IsPageCountValid
        {
            get { return _originalPaginator.IsPageCountValid; }
        }
    
        public override int PageCount
        {
            get { return _originalPaginator.PageCount; }
        }
    
        public override Size PageSize
        {
            get { return _newPageSize; }
            set { SetPageSize(value); }
        }
    
        public override IDocumentPaginatorSource Source
        {
            get { return _originalPaginator.Source; }
        }
    }
