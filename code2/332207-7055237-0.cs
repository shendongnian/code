    using System;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    namespace GraphicsHandler
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
               InitializeComponent();
            }
            private void textBox1_TextChanged(object sender, EventArgs e)
            {
                // Check the width of the text whenever it is changed.
                if (checkTextWillFit(textBox1.Text) == true)
                {
                     MessageBox.Show("Entered test is too wide, please reduce the number of characters.");
                }
            }
            private bool checkTextWillFit(string enteredText)
            {
                // Create a handle to the graphics property of the PrintPage object
                Graphics g = pd.PrinterSettings.CreateMeasurementGraphics();
                // Set up a font to be used in the measurement
                Font myFont = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Millimeter);
                // Measure the size of the string using the selected font
                // Return true if it is too large
                if (g.MeasureString(enteredText, myFont).Width > 100)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            PrintDocument pd = null;
            private void Form1_Load(object sender, EventArgs e)
            {
                // Initialise the print documnet used to render the printed page
                pd = new PrintDocument();
                // Create the event handler for when the page is printed
                pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            }
            void pd_PrintPage(object sender, PrintPageEventArgs e)
            {
                // Page printing logic here            
            }
        } 
    }
