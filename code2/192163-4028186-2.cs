	public partial class Default : SitePageBase<Default>
	{
            [Dependency]
            public IContentService ContentService { get; set; }
            protected override void OnPreRender( EventArgs e )
            {
                this.label.Text = ContentService.GetContent("labelText");
            }
         }
