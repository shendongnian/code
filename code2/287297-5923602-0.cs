    public class MasterBasePage : System.Web.UI.MasterPage
            {
            
                private string _pageTitle;
            
                private string _pageDescription;
                public string PageTitle
                {
                    get { return _pageTitle; }
                    set { _pageTitle = value; }
                }
            
                public string PageDescription
                {
                    get { return _pageDescription; }
                    set { _pageDescription = value; }
                }
            
                protected override void OnLoad(EventArgs e)
                {
                    if (string.IsNullOrEmpty(PageTitle))
                    {
                        _pageTitle = this.Page.Title;
                    }
                    _pageDescription = "Select from config file";
                    this.Page.Title = "Page Title";
                    HtmlMeta metaTag = new HtmlMeta();
                    metaTag.Name = "Description";
                    metaTag.Content = _pageDescription;
                    Page.Header.Controls.Add(metaTag);
            
                    base.OnLoad(e);
                }
            }
