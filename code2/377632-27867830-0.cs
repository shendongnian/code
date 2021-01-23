        //Begin Form1 Code
        //Delcalre a string to be used by Form1 for a value eventually returned from Form2
        private string returnedValue;
        //Declare a string that can be accessed outside of Form1 by Form2
        public string returnValue
        {
            get { return returnedValue; }
            set { returnedValue = value; }
        }
        public Form1()
        {
            InitializeComponent();
            this.Load += Form1_Load;
        }
        void Form1_Load(object sender, EventArgs e)
        { 
            /*
             Form1_Load can be used to loop back and forth from Form1 to Form2
             which can be useful when writing spiders for custom search engines
             but this type of functionality is not needed for this example.
            */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); //This will hide Form1, could also use this.Close();
            Form2 f2 = new Form2(); //Declare instance of Form2
            f2.passValue = textBox1.Text; //Grab text from textBox1 and pass to Form2!
            f2.Show(); //Run Form2 with passed value now available!
        }
        //End Form1 Code
        //Begin Form2 Code
        //Please excuse the naming convention :-)
        //The super long string Ids are intended to be helpful
        private string valueFromForm1ToBeUsedInForm2; 
        public string passedValueFromForm1
        {
            get {return valueFromForm1ToBeUsedInForm2;}
            set { valueFromForm1ToBeUsedInForm2 = value; }
        }
        public Form2()
        {
            InitializeComponent();
            this.Load += Form2_Load;
        }
        void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = valueFromForm1ToBeUsedInForm2;
            Form1 f1 = new Form1(); //Declare a new instance of Form1
            
            //The following would send back to Form1 the value previously sent from Form1
            f1.returnValue = valueFromForm1ToBeUsedInForm2;
            //or you could send back a new value to Form1 by commenting out above f1.returnValue 
            //and uncomment below
            //f1.returnValue = "maybe a value derived using original value sent by Form1";
            // The following will redirect back to Form1 and close Form2 automatically
            // You may want to handle this with a button event if not building a spider
            // or custom search engine
            f1.Show();
            this.Close();
        }
        //End Form2
