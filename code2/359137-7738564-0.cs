        Assuming Class1 is the class which does some process in thread. Create the property which corresponds to type of your main form. In this case, its called Form1. 
        
        
        
         class Class1
            {
        //his is the property
                public Form1 MyMainForm { get; set; }
                
                public  void    ShowText()
                {
        
    //here the control is accesses 
    //((TextBox)MyMainForm.Controls.Find("textBox1",true)[0])
                    MessageBox.Show(((TextBox)MyMainForm.Controls.Find("textBox1",true)[0]).Text);
                }
            }
        
        im assuming ShowText() method is called on new thread, when button is clicked.
        
         private void button1_Click(object sender, EventArgs e)
                {
        //craete instance of class1
                    Class1 c = new Class1();
        //set the  property            
        c.MyMainForm = this;
        //start the method is new thread
                    ThreadStart ts=new ThreadStart(c.ShowText);
                    Thread t=new Thread(ts);
                    t.Start();
                }
