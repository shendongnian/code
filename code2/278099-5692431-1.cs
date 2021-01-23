    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Create an instance of your custom control
            mydatagridview myDGV = new mydatagridview();
            // Add that instance to your form's Controls collection
            this.Controls.Add(myDGV);
        }
    }
