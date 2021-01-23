      Validation.WebService validate = new Validation.WebService();
        bool ismail = (!string.IsNullOrEmpty(Textbox2.Text)) &&  validate.isEmail(TextBox2.Text);
        if (!ismail) 
        {
            Label1.Text = "your mail is wrong!!";
        }
        Validation.nameVal valid = new Validation.nameVal();
        
        bool isname = (!string.IsNullOrEmpty(Textbox1.Text)) && valid.isName(TextBox1.Text); 
        
        if (!isname) 
        {
            Label2.Text = "Your name is wrong!!"; 
        } 
        else if (string.IsNullOrEmpty(Textbox1.Text)) 
        {
            Label2.Text = "Please fill in your name"; 
        } 
        
        if (isname && ismail) 
        {
            {
                Label1.Text = "";
                Label2.Text = "";
                Label3.Text = "Your message has been send!";
            }
        }
    }
