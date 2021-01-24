     int intVisits;
      HttpCookie CkNombreVisits = null;
                if (Request.Cookies["CkVisits"] != null)
                {
                    HttpCookie CkNombreVisits = Request.Cookies["CkVisits"];
                    intVisits = Convert.ToInt16(CkNombreVisits );
                    lblVisits.Text = Convert.ToString(intVisits);
        
                    intVisits++; //to add a new visit
                    CkNombreVisits["CkVisits"] = Convert.ToString(intVisits);
                    //here its says that CkNombreVisits doesn't exist
                }
                else
                {
        
                    HttpCookie CkNombreVisits = new HttpCookie("CkVisits");
                    CkNombreVisits.Expires = DateTime.Now.AddDays(20);
                    CkNombreVisits["CkVisits"] = "0";
                    lblVisits.Text = Convert.ToString(Request.Cookies["CkVisits"]);
        
                    intVisits = Convert.ToInt16(Request.Cookies["CkVisits"]);
                    intVisits++;
                    CkNombreVisits["CkVisits"] = Convert.ToString(intVisits);
                    
                }
    
    Response.Cookies.Add(CkNombreVisits);
