     if (this.Page.PreviousPage != null)
            {
                Control ContentPlaceHolder1 = this.Page.PreviousPage.Master.FindControl("ContentPlaceHolder1");
                TextBox txtDate = (TextBox)ContentPlaceHolder1.FindControl("txtDate");
            }
