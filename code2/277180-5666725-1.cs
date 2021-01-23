    public void StartConnection(string name)
    {
        //var myForm = Form.ActiveForm as Form2;
    	var myForm = Application.OpenForms["Form2"] as Form2;
    	myForm.textBox1.Text = "Hello world!";  /// <- this one trows “System.NullReferenceException was unhandled”
    											/// unless Form2 is selected when this fires.
    
    	callback.Message_Server2Client("Welcome, " + name );
    }
