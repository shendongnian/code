    protected void Page_Load(object sender, EventArgs e) {
        Session["IsAuthenticated"] = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "abc" && TextBox2.Text == "xyz")
            {
                Session["IsAuthenticated"] = "Y";
                if (!String.IsNullOrEmpty((string)Session["GoToFinal"]) && (string)Session["GoToFinal"] == "Y")
                {
                    Response.Redirect("final.aspx");
                }
                else
                {
                    Response.Redirect("main.aspx");
                }
            }
            else
            {
                Response.Write("Login Failed");
            }
        }
