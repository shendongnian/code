There is no need to create a hidden Window, you can render WPF controls for printing by using a [DocumentPage][1].  To print DocumentPages , you will need to need to extend the [DocumentPaginator][2] class.
The code to implement an a simple DocumentPaginator that will print out any List of UIElements is below.
    class DocumentPaginatorImpl : DocumentPaginator
    {
        private List<UIElement> Pages { get; set; }
        public DocumentPaginatorImpl(List<UIElement> pages)
        {
            Pages = pages;
        }
        public override DocumentPage GetPage(int pageNumber)
        {
            return new DocumentPage(Pages[pageNumber]);
        }
        public override bool IsPageCountValid
        {
            get { return true; }
        }
        public override int PageCount
        {
            get { return Pages.Count; }
        }
        public override System.Windows.Size PageSize
        {
            get
            {
                /* Assume the first page is the size of all the pages, for simplicity. */
                if (Pages.Count > 0)
                {
                    UIElement page = Pages[0];
                    if (page is Canvas)
                        return new Size(((Canvas)page).Width, ((Canvas)page).Height);
                    // else if ...
                }
                return Size.Empty;
            }
            set
            {
                /* Ignore the PageSize suggestion. */
            }
        }
        public override IDocumentPaginatorSource Source
        {
            get { return null; }
        }
    }
