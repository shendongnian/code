        private void LoadCities()
        {
            try
            {
                List<City> cityList = new cityBLL().GetAllcity();                
                
                ddlGender.DataSource = cityList;
                ddlGender.DataTextField = "Name";
                ddlGender.DataValueField = "ID";
                ddlGender.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
