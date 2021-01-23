    public class BaseContentTeaserPage : Page
    {
        private Guid _pageId;
        protected PlaceHolder plc;
        protected override void OnPreInit(EventArgs e)
        {
            _pageId = Guid.Parse(Request.QueryString["pageId"]);
            using (new DataScope(PublicationScope.Published, new CultureInfo("en-GB")))
            {
                using (var data = new DataConnection())
                {
                    PageRenderer.CurrentPage = data.Get<IPage>().Single(p => p.Id == _pageId);
                    var urlData = new PageUrlData(PageRenderer.CurrentPage);
                    urlData.PathInfo = Request.QueryString["pathInfo"];
                    Context.Items["C1_PageUrl"] = urlData;
                }
            }
            base.OnPreInit(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            using (new DataScope(PublicationScope.Published, new CultureInfo("en-GB")))
            {
                var content = DataFacade.GetData<IPagePlaceholderContent>().Single(p => p.PageId == _pageId);
                var helper = new PageRendererHelper();
                var mapper = (IXElementToControlMapper)helper.FunctionContext.XEmbedableMapper;
                var doc = helper.RenderDocument(content);
                var body = PageRendererHelper.GetDocumentPart(doc, "body");
                addNodesAsControls(body.Nodes(), plc, mapper);
                if (Page.Header != null)
                {
                    var head = PageRendererHelper.GetDocumentPart(doc, "head");
                    if (head != null)
                    {
                        addNodesAsControls(head.Nodes(), Page.Header, mapper);
                    }
                }
            }
            base.OnLoad(e);
        }
        private static void addNodesAsControls(IEnumerable<XNode> nodes, Control parent, IXElementToControlMapper mapper)
        {
            foreach (var node in nodes)
            {
                var c = node.AsAspNetControl(mapper);
                parent.Controls.Add(c);
            }
        }
        protected override void Render(HtmlTextWriter writer)
        {
            var markupBuilder = new StringBuilder();
            using (var sw = new StringWriter(markupBuilder))
            {
                base.Render(new HtmlTextWriter(sw));
            }
            string xhtml = markupBuilder.ToString();
            using (Profiler.Measure("Changing 'internal' page urls to 'public'"))
            {
                xhtml = PageUrlHelper.ChangeRenderingPageUrlsToPublic(xhtml);
            }
            using (Profiler.Measure("Changing 'internal' media urls to 'public'"))
            {
                xhtml = MediaUrlHelper.ChangeInternalMediaUrlsToPublic(xhtml);
            }
            writer.Write(xhtml);
        }
    }
