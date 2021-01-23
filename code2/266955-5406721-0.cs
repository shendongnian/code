     using (OdbcCommand cmd = new OdbcCommand("SELECT Wallpostings FROM WallPosting WHERE UserID=" + userId + " ORDER BY idWallPosting DESC", cn))
            {
                using (OdbcDataReader reader = cmd.ExecuteReader())
                {
                    var divHtml = new System.Text.StringBuilder();
                    while (reader.Read())
                    {
                        System.Web.UI.HtmlControls.HtmlGenericControl div = new System.Web.UI.HtmlControls.HtmlGenericControl("div");
                        div.ID = "test";
                        div.InnerHtml = String.Format("{0}", reader.GetString(0));
                        Image img = new Image();
                        img.ImageUrl = "~/images/test.jpg";
                        img.AlternateText = "Test image";
                        div.Controls.Add(img);
                        test1.Controls.Add(div);
                    }
                    test1.InnerHtml = divHtml.ToString();
                }
            }
