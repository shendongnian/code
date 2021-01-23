    public partial class UserProfileWall : System.Web.UI.Page
    {
    
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                //It is a postback so check if it was by div click (NOT WORKING because the javascript isnt posting back)
                string target = Request["__EVENTTARGET"];
                if (target == "DivClicked")
                {
                    string id = Request["__EVENTARGUMENT"];
                    //Call my delete function passing record id
                    Response.Write(String.Format(id)); //just a test 
                }
            }
            string theUserId = Session["UserID"].ToString();
            PopulateWallPosts(theUserId);
        }
        private void PopulateWallPosts(string userId)
        {
    
            using (OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=root; Password=commando;"))
            {
                cn.Open();
                using (OdbcCommand cmd = new OdbcCommand("SELECT idWallPosting, wp.WallPostings, p.PicturePath FROM WallPosting wp LEFT JOIN User u ON u.UserID = wp.UserID LEFT JOIN Pictures p ON p.UserID = u.UserID WHERE wp.UserID=" + userId + " ORDER BY idWallPosting DESC", cn))
                {
                    //("SELECT wp.WallPostings, p.PicturePath FROM WallPosting wp LEFT JOIN [User] u ON u.UserID = wp.UserID LEFT JOIN Pictures p ON p.UserID = u.UserID WHERE UserID=" + userId + " ORDER BY idWallPosting DESC", cn))
                    using (OdbcDataReader reader = cmd.ExecuteReader())
                    {
                        test1.Controls.Clear();
    
                        while (reader.Read())
                        {
    
                            System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                            div.Attributes["class"] = "test";
    
    
                            div.ID = String.Format("{0}", reader.GetString(0));
                            string id = Convert.ToString(div.ID);
                            //store the div id as a string
                            Image img = new Image();
                            img.ImageUrl = String.Format("{0}", reader.GetString(2));
                            img.AlternateText = "Test image";
    
                            div.Controls.Add(img);
                            div.Controls.Add(ParseControl(String.Format("&nbsp&nbsp&nbsp;" + "{0}", reader.GetString(1))));
                            div.Attributes.Add("onclick", "return confirm_delete(" + id + ");");
                            // send the div id to javascript
                            div.Style["clear"] = "both";
                            test1.Controls.Add(div);
    
                        }
                    }
                }
            }
        }
    
    
    
        protected void Button1_Click(object sender, EventArgs e)
        {
            string theUserId = Session["UserID"].ToString();
            using (OdbcConnection cn = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver}; Server=localhost; Database=gymwebsite2; User=root; Password=commando;"))
            {
                cn.Open();
                using (OdbcCommand cmd = new OdbcCommand("INSERT INTO WallPosting (UserID, Wallpostings) VALUES (" + theUserId + ", '" + TextBox1.Text + "')", cn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            PopulateWallPosts(theUserId);
        }
    }
