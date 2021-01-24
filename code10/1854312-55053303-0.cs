    if (Status != null)
            {
                System.Web.HttpContext.Current.Session["Status"] = Status;
            }
            if (System.Web.HttpContext.Current.Session["Status"] != null)
            {
                Status = System.Web.HttpContext.Current.Session["Status"].ToString();
            }
            if (Type != null)
            {
                System.Web.HttpContext.Current.Session["Type"] = Type;
            }
            if (System.Web.HttpContext.Current.Session["Type"] != null)
            {
                Type = System.Web.HttpContext.Current.Session["Type"].ToString();
            }
                       
            if (Name != null)
            {
                System.Web.HttpContext.Current.Session["Name"] = Name;
            }
            if (System.Web.HttpContext.Current.Session["Name"] != null)
            {
                Name = System.Web.HttpContext.Current.Session["Name"].ToString();
            }
            if (Site != null)
            {
                System.Web.HttpContext.Current.Session["Site"] = Site;
            }
            if (System.Web.HttpContext.Current.Session["Site"] != null)
            {
                Site = System.Web.HttpContext.Current.Session["Site"].ToString();
            }
            if (Acct != null)
            {
                System.Web.HttpContext.Current.Session["Acct"] = Acct;
            }
            if (System.Web.HttpContext.Current.Session["Acct"] != null)
            {
                Acct = System.Web.HttpContext.Current.Session["Acct"].ToString();
            }
            if (City != null)
            {
                System.Web.HttpContext.Current.Session["City"] = City;
            }
            if (System.Web.HttpContext.Current.Session["City"] != null)
            {
                City = System.Web.HttpContext.Current.Session["City"].ToString();
            }
            if (State != null)
            {
                System.Web.HttpContext.Current.Session["State"] = State;
            }
            if (System.Web.HttpContext.Current.Session["State"] != null)
            {
                State = System.Web.HttpContext.Current.Session["State"].ToString();
            }
            if (Address != null)
            {
                System.Web.HttpContext.Current.Session["Address"] = Address;
            }
            if (System.Web.HttpContext.Current.Session["Address"] != null)
            {
                Address = System.Web.HttpContext.Current.Session["Address"].ToString();
            }
