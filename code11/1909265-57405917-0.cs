       if(string.IsNullOrEmpty(Session["userCountryAbbr"] as string))
        {
            Session["userCountryAbbr"] = userCountry;
            if(!countryList.Contains(userCountry.ToString()))
            {
              Response.Redirect("/en-ng");
            }
            else
            {
              Response.Redirect("/en-" + userCountry);
            }
        }
        else
        {
           Session["userCountryAbbr"] = "";
        }
