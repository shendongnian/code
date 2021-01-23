            Label1.Text = WebUserControl11.GetFirstName;
            Label2.Text = WebUserControl11.GetLastName;
            Label3.Text = WebUserControl12.GetFirstName;
            Label4.Text = WebUserControl12.GetLastName;
        }
        protected void ClearFields(object sender, EventArgs e)
        {
            WebUserControl11.GetFirstName = string.Empty;
            WebUserControl11.GetLastName = string.Empty;
            WebUserControl12.GetFirstName = string.Empty;
            WebUserControl12.GetLastName = string.Empty;
        }
