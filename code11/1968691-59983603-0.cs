        private void GetUsers()
         {
             OriginatorDropDown.Items.Clear();
             OriginatorDropDown.DataSource = GetUserData();
             OriginatorDropDown.DataBind();
    
             
    using (PrincipalContext pc = new PrincipalContext(ContextType.Domain))
             foreach (ListItem ltItem in OriginatorDropDown.Items)
             {
                 if (ltItem.Text != String.Empty)
                 {
                     
                     
                         UserPrincipal up = UserPrincipal.FindByIdentity(pc, IdentityType.SamAccountName
    ,ltItem.Text);
                         if (up != null)
                         {
                             ltItem.Text = up.DisplayName;
                         }
    
                     
                 }
             }
         }
