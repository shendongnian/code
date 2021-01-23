    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
                {
                    DropDownList ddlCountry = (DropDownList)sender;
                    DropDownList ddlCity = (DropDownList)((DropDownList)sender).Parent.Parent.FindControl("ddlCity");
                    BindCity(ddlCity, ddlCountry.SelectedValue);
                }
        
        private void BindCity(DropDownList ddlCity, string countryCode)
                {
        // Binding code of city based selected country
        }
