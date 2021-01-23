        protected void Page_Load(object sender, EventArgs e)
        {
            dl.DataSource = GroupsHndlr.GetExtendedRecipients(MySession.Current.ClientId);
            dl.DataBind();
        }
    }
