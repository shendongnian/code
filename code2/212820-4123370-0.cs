    //In Form2
    public Form RefToForm1 { get; set;}
    
    //In Form1
    Form2 obj2 = new Form2();
    obj2.RefToForm1 = this;
    this.Visible = false;
    obj2.Show();
    
    //In Form2, where you need to show Form1:
    this.RefToForm1.Show();
