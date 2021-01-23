        protected void Page_Load(object sender, EventArgs e)
        {
            foreach (MenuItem m in NavigationMenu.Items)
            {
                if (m.NavigateUrl.ToString() == "~" + HttpContext.Current.Request.Url.LocalPath.ToString())
                {
                    m.Selected = true;
                }
                else
                {
                    m.Selected = false;
                }
            }
            this.DataBind();
        }
