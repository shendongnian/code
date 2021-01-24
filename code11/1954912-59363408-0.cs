SPSite siteCollection = this.Site;
SPWeb site = this.Web;
// obtain query string values
string ListId = Request.QueryString["ListId"];
string ItemId = Request.QueryString["ItemId"];
// create list object and list item object
SPList list = site.Lists[new Guid(ListId)];
SPListItem item = list.Items.GetItemById(Convert.ToInt32(ItemId));
// query for information about list and list item
string ListTitle = list.Title;
string ItemTitle = item.Title;
if (list is SPDocumentLibrary) {
  SPDocumentLibrary documentLibrary = (SPDocumentLibrary)list;
  string DocumentTemplateUrl = documentLibrary.DocumentTemplateUrl;
  SPFile file = item.File;
  string FileAuthor = file.Author.Name;
  string FileSize = file.TotalLength.ToString("0,###") + " bits";
}
