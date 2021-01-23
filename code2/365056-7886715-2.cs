    //Add public property to Form1 class
    public string ValueFromForm2 { get; set; }
    //When Form2 is created, set the reference property
    Form2 objForm2 = new Form2();
    objForm2.CallingForm = this;
    objForm2.Show();
