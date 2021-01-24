    public class PageLinkTagHelper : TagHelper
        {
            private IUrlHelperFactory urlHelperFactory;
            public PageLinkTagHelper(IUrlHelperFactory helperFactory)
            {
                urlHelperFactory = helperFactory;
            }
            [ViewContext]
            [HtmlAttributeNotBound]
            public ViewContext ViewContext { get; set; }
            public PagingInfo PageModel { get; set; }
            public string PageAction { get; set; }
    
            public override void Process(TagHelperContext context, TagHelperOutput output)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                output.TagName = "div";
    
                // набор ссылок будет представлять список ul
                TagBuilder tag = new TagBuilder("ul");
                tag.AddCssClass("pagination");
    
                // формируем три ссылки - на текущую, предыдущую и следующую
                TagBuilder currentItem = CreateTag(PageModel.PageNumber, urlHelper);
    
                // создаем ссылку на предыдущую страницу, если она есть
                if (PageModel.HasPreviousPage)
                {
                    TagBuilder prevItem = CreateTag(PageModel.PageNumber - 1, urlHelper);
                    tag.InnerHtml.AppendHtml(prevItem);
                }
    
                tag.InnerHtml.AppendHtml(currentItem);
                // создаем ссылку на следующую страницу, если она есть
                if (PageModel.HasNextPage)
                {
                    TagBuilder nextItem = CreateTag(PageModel.PageNumber + 1, urlHelper);
                    tag.InnerHtml.AppendHtml(nextItem);
                }
                output.Content.AppendHtml(tag);
            }
    
            TagBuilder CreateTag(int pageNumber, IUrlHelper urlHelper)
            {
                TagBuilder item = new TagBuilder("li");
                TagBuilder link = new TagBuilder("a");
                if (pageNumber == this.PageModel.PageNumber)
                {
                    item.AddCssClass("active");
                }
                else
                {
                    link.Attributes["href"] = urlHelper.Action(PageAction, new { page = pageNumber });
                }
                link.InnerHtml.Append(pageNumber.ToString());
                item.InnerHtml.AppendHtml(link);
                return item;
            }
        }
    }
