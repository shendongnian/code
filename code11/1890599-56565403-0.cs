        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void txtVal1_TextChanged(object sender, EventArgs e)
        {
            Session["Q1"] = txtVal1.Text;
            lblVal1.Text = txtVal1.Text;
        }
        protected void txtVal2_TextChanged(object sender, EventArgs e)
        {
            Session["Q2"] = txtVal2.Text;
            lblVal2.Text = txtVal2.Text;
        }
        protected void txtVal3_TextChanged(object sender, EventArgs e)
        {
            Session["Q3"] = txtVal3.Text;
            lblVal3.Text = txtVal2.Text;
        }
