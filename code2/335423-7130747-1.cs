        public Form1()
        {
            InitializeComponent();
            Form2 form2 = new Form2();
            form2.updateEvent += new EventHandler<Form2.UpdatedEventArgs>(form2_updateEvent); // create event handler to update form 1 from form 2
            form2.Show();
        }
        void form2_updateEvent(object sender, Form2.UpdatedEventArgs e)
        {
            if (e != null && e.SomeVal != null)
            {
                // Do the update on Form 1 
                // depend on your event arguments update the grid  
                //MessageBox.Show(e.SomeVal); 
            }
              
        }
