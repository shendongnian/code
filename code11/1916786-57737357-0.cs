TagBuilder result = new TagBuilder("div");
for (int i = 1; i <= PageModel.TotalPages; i++)
{
     TagBuilder tag = new TagBuilder("a");
     tag.Attributes["href"] = urlHelper.Action(PageAction, new { ProductPage = i });     
     // tag was being added to itself, rather add it the container `div`
     // tag.InnerHtml.AppendHtml(tag);
     result.InnerHtml.AppendHtml(tag);
}
