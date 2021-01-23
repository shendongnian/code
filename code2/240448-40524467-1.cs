    [WebMethod(EnableSession = true)]
        public List<string> Display()
        {
            List<string> li1 = new List<string>();
            if (Session["Name"] == null)
            {
               
                li1.Add("No record to display");
                return li1;
            }
               
            else
            {
                string[] names = Session["Name"].ToString().Split(',');
                foreach(string s in names)
                {
                    li1.Add(s);
                }
    
                return li1;
            }
    
        }
