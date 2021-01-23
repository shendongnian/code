    protected override void OnInit(EventArgs e)
    {
        Control userControl = this.Page.LoadControl("WebUserControl.ascx");
        testPlaceHolder.Controls.Add(userControl);
        userControl.ID="id"; 
        base.OnInit(e);
    }
    protected void testButton_Click(object sender, EventArgs e)
    {
        Control testUserControl = (Control)testPlaceHolder.Controls[0];
      //Control testUserControl=(Control)testPlaceHolder.FindControl("id");
        TextBox mytextbox = (TextBox)testUserControl.FindControl("testTextBox");
        testButton.Text = mytextbox.Text;
    }
