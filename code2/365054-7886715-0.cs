    public string ValueFromForm1 { get; set; }
    
    //In the constructor, or other relevant method, I use the value
    public Form2()
    {
      form2LabelToDisplayForm1Value.Text = ValueFromForm1;
    }
