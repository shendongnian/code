    //Form2
    private Form refToForm1;
    public Form RefToForm1
    {
       get { return refToForm1; }
       set { refToForm1 = value; }
    }
   
     // On buttonClick
           CheckBox cb=(CheckBox)this.RefToForm1.Controls["checkBox1"];
           cb.Checked = !cb.Checked;
  
    //Form1
    
     Form2 obj2 = new Form2();
     obj2.RefToForm1 = this;
     obj2.Show();
