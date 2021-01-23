    protected void btnMultiply_Click(object sender, EventArgs e)
    {
        if (TextBox1.Text == "")
        {
            return;
        }
        else
        {
            multiply = true;
            Session["multiply"] = multiply
            Session["Tag"] = TextBox1.Text;
            TextBox1.Text = "";
        }
    }
    protected void Equals_click(...)
    {       
       //This is not a complete code but just to give you an idea
       bool mul = Session["multiply"] == null ? false : (bool)Session["multiply"];
       ...
       else if (mul)
       ...      
    }
