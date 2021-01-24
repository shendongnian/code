    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dtGetData = GetDataTable();
    
             Note:- As per your Table Data structure ...one user have only one Page Access...
    		         User Only Get only one Row....check sepratly...one easy method...	
    
                if (dtGetData != null && dtGetData.Rows.Count > 0)
                {
                    if (dtGetData.Rows[0]["form_name"] == "WebpageA.aspx")
                    {
                        lnkWebpage4.Visible = true;  //Here Other 2 menu will be Hide....
                    }
    
                    else if (dtGetData.Rows[0]["form_name"] == "WebpageB.aspx")
                    {
                        lnkWebpage5.Visible = true;
                    }
    
                    else if (dtGetData.Rows[0]["form_name"] == "WebpageC.aspx")
                    {
                        lnkWebpage6.Visible = true;
                    }
    
                }
            }
        }
