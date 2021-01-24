        protected void Login_Click(object sender, EventArgs e)
                {
                    Session["LoggedIn"] = emailTxtBx.Text;
                    ViewBag.Message = "This is Login Message";       
                    Response.Redirect("~/UL/Home.aspx");
                }
