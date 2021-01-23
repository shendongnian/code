        protected void Button1_Click(object sender, EventArgs e)
        {
            WebApplication7.linqDataContext db = new WebApplication7.linqDataContext();
            
            int recordCount = 0;
            recordCount  = db.uporabnikis.where(x => x.username == "usernametocheck" && x.password = "passwordtocheck").Count();
            if (recordCount > 0)
            {
                //code to redirect
            }
            else
            {
                //Display error
            }
        }
