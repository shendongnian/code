System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
div.Attributes["class"] = "test";
div.ID = "test";
// Deletebutton div with link
System.Web.UI.HtmlControls.HtmlGenericControl divClose = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
divClose.Attributes["class"] = "closeButton";
divClose.ID = "closeButton";
div.Controls.Add(divClose);
System.Web.UI.HtmlControls.HtmlGenericControl link= new System.Web.UI.HtmlControls.HtmlGenericControl("a");
link.ID = "link";
divClose.Controls.Add(link);
img = new Image();
ImageUrl = String.Format("{0}", reader.GetString(1));
img.AlternateText = "Test image";
div.Controls.Add(img);
div.Controls.Add(ParseControl(String.Format("{0}", reader.GetString(0))));
div.Style["clear"] = "both";
test1.Controls.Add(div);
