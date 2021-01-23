    protected void btn_Click(object sender, EventArgs e)
    {
       string inlineCss = "your css goes here";
       //I'm assuming the text you want to apply css to is a Label with ID=label
       label.Attributes.Add("style", inlineCss);
    }
