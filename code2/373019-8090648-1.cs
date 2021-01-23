     private void Link_Click(object sender, EventArgs e)
        {
            LinkButton button = sender as LinkButton;
            if (button.Text == "LinkButton1")
            {
                Response.Write("<script>alert('link1');</script>");
            }
            else if (button.Text == "LinkButton2")
            {
                Response.Write("<script>alert('link2');</script>");
            }
        }
