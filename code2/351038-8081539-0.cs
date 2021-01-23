        protected void OptionsInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList optionsInput = sender as DropDownList;
            DropDownList ddl2 = optionsInput.Parent.FindControl("AttributesInput") as DropDownList;
            if (ddl2 is DropDownList)
            {
                ddl2.DataValueField = "ID";
                ddl2.DataTextField = "Title";
                if (optionsInput.SelectedIndex != 0)
                {
                    ddl2.DataSource = this.SecondDDLItems.Where(f => f.ForeignKey == Convert.ToInt32(optionsInput.SelectedValue));
                    ddl2.DataBind();
                }
            }
        }
