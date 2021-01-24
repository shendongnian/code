using System;
using System.Windows.Forms;
namespace FixedDebugThree3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        //declare class-wide variable to hold running total
        private double total = 0;
        private void TotalButton_Click(object sender, EventArgs e)
        {
            //c# 7 syntax allows us to neatly declare a "num" variable as part of the out parameter
            //your original code tried to convert the whole textbox to double. You need to use the .Text
            if(double.TryParse(textBox1.Text, out var num))
            {
               total += num;
               outputLabel.Text = "Running total:" + total);
            } else { // if parsing the number failed- (write defensive code that consumes user input)
               outputLabel.Text = "Please enter a valid number. Current Running total:" + total);
            }
        }
    }
}
If you're on c#6 or earlier then the syntax above will need tweaking to:
    double num;
    if(double.TryParse(textBox1.Text, out num)) {
