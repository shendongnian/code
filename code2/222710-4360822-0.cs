    namespace Mileage
    {
      public partial class Form2 : Form
      {
        private float beginMileage, endMileage, gallons, mpg;        
        
        public Form2()
        {
            InitializeComponent();
        }
        public void menuItem1_Click(object sender, EventArgs e)
        {
            beginMileage = float.Parse(this.textBox1.Text.Replace(" ", ""));
            endMileage = float.Parse(this.textBox2.Text.Replace(" ", ""));
            gallons = float.Parse(this.textBox3.Text.Replace(" ", ""));
            if((endMileage<0)||(beginMileage<0)||(gallons<0))
            {
                 this.label5.Text = String.Format("ERROR: One or more input(s) is negative.");
                 this.textBox1.Text = " ";
                 this.textBox2.Text = " ";
                 this.textBox3.Text = " ";   
            }
            else if ((endMileage == 0) || (gallons == 0))
            {
                this.label5.Text = String.Format("ERROR: The end mileage and/or gallon input is zero.");
                this.textBox1.Text = " ";
                this.textBox2.Text = " ";
                this.textBox3.Text = " ";                 
            }
            else if (endMileage < beginMileage)
            {
                this.label5.Text = String.Format("ERROR: End mileage is less than begining mileage.");
                this.textBox1.Text = " ";
                this.textBox2.Text = " ";
                this.textBox3.Text = " ";
            }
            else 
            {                               
                mpg = ((endMileage - beginMileage) / gallons);
                this.label5.Text = String.Format("{0}", mpg);
            }
            
        }
        public void menuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();            
        }
    }
}
