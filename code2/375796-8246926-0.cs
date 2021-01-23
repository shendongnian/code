        public void MyMethod(EventArgs e)
        {
            
                var button = e.Row.Cells[5].FindControl("linkButtonName") as LinkButton;
                SetButtonVisibility(button);
        }
        public void SetButtonVisibility(LinkButton button)
        {
            //The button is never null so its a contract
            Contract.Requires<ArgumentNullException>(button != null);
            
            button.Visible = (schedule.CreatedBy == Authentification.GetLoggedInUser());
        }
