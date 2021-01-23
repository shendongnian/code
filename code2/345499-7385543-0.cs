        List<string> strMale = new List<string>{"Mr.", "Dr. "};
        List<string> strFMale = new List<string>{"Mrs.", "Miss"};
    
    //make use of Textbox Change Event
    public void Text1_TextChanged(object sender, EventArgs e)
    {
      //Bind the values using the text box input value 
      if(Text1.Text=="0")
       {
         Combo1.DataSource = strMale ;
       }
       else 
        if(Text1.Text=="0")
       {
         Combo1.DataSource = strFMale ;
       }
    }
