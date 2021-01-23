            if (!IsPostBack)
            {
                // your code to bind the first drop downlist
            }
        }
        protected void DDLFirst_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLFirst.SelectedIndex > 0)
            {
                string FirstDDLValue = DDLFirst.SelectedItem.Value;
                // below your code to get the second drop down list value filtered on first selection
            }
        }
        protected void DDLSecond_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDLSecond.SelectedIndex > 0)
            {
                string SecondDDLValue = DDLSecond.SelectedItem.Value;
                // below your code to get the third drop down list value filtered on Second selection
            }
        }
