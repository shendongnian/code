        public partial class Form2 : Form
    {
        //This is the Constructor
        public Form2()
        {
            InitializeComponent();
        }
        //This is an overloaded constructor that takes a url argument
        public Form2(string URL )
        {
            InitializeComponent();
            //Store the URL For Later
            URLToDisplay = URL
        }
        //Property that you can access any where you have a reference to the form instance
        public int URLToDisplay { get; set; }
    }
