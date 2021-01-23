    protected void Page_Load(object sender, EventArgs e)
    {
        Label3.Text = "this is label three";
        Label3.Attributes.Add("OnMouseOver", "testmouseover()");
    }
    [webmethod]
    public static void testmouseover()
    {
        // Implement this static method
    
    }
