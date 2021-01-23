    protected void Button_AddNewCourse_Click(object sender, EventArgs e)
    {
        Session["ID"] = 10;
    }
    protected void AnotherFunction(object sender, EventArgs e)
    {
        int tempID = (int)Session["ID"];
    }
