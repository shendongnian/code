    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Drawing.Printing;//Needed for the PrintDocument()
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace Printing
    {
        public partial class Form1 : Form
        {
            private Font printFont1;
            string strPrintText;
    
            public Form1()
            {
                InitializeComponent();
            }
            //PrintDocument printDocument1 = null; In ny case it makes this error: 'Printing.Form1' already contains a definition for 'primtDocument1'
            private void Form1_Load(object sender, EventArgs eP)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += new PrintPageEventHandler
                (this.printDocument1_PrintPage);
            }
            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
                // Check the width of the text whenever it is changed.
                if (checkTextWillFit(richTextBox1.Text) == true)
                {
                    MessageBox.Show("\nEntered text pruduces too many lines. \n\nPlease reduce the number of characters.", "Too Many Lines");
                }
            }
    
            private bool checkTextWillFit(string enteredText)
            {
                StringFormat format1 = new StringFormat();
                format1.Trimming = StringTrimming.Word; //Word wrapping
                RectangleF rectfText;
                int iCharactersFitted, iLinesFitted;
    
                rectfText = new RectangleF(60.0F, 200.0F, 560.0F, 200.0F);
                // Create a handle to the graphics property of the PrintPage object
                Graphics g = printDocument1.PrinterSettings.CreateMeasurementGraphics();
    
                // Set up a font to be used in the measurement
                Font myFont = new Font("Times New Roman", 10, FontStyle.Regular);
    
                // Measure the size of the string using the selected font
                // Return true if it is too large
                g.MeasureString(enteredText, myFont, rectfText.Size, format1, out iCharactersFitted, out iLinesFitted);
                if (iLinesFitted > 12)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            private void cmdPrint_Click(object sender, EventArgs e)
            {
                try
                {
                    PrintDocument pdocument = new PrintDocument();
                    pdocument.PrintPage += new PrintPageEventHandler
                    (this.printDocument1_PrintPage);
                    pdocument.Print();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            public void printDocument1_PrintPage(object sender,
              System.Drawing.Printing.PrintPageEventArgs e)
            {
                strPrintText = richTextBox1.Text.ToString();
                printFont1 = new Font("Times New Roman", 10); //I had to remove this line fromthe btnPrintAnexo1_Click
                Graphics g = e.Graphics;
                //float cyFont = printFont1.GetHeight(g);
                StringFormat format1 = new StringFormat();
                format1.Trimming = StringTrimming.Word; //Word wrapping
                RectangleF rectfText;
                int iCharactersFitted, iLinesFitted;
    
                rectfText = new RectangleF(60.0F, 200.0F, 560.0F, 200.0F);
                // The following e.Graphics.DrawRectangle is
                // just for debuging with printpreview
                e.Graphics.DrawRectangle(new Pen(Color.Black, 1F),
                  rectfText.X, rectfText.Y, rectfText.Width, rectfText.Height);
    
                //Here is where we get the quantity of characters and lines used 
                g.MeasureString(strPrintText, printFont1, rectfText.Size, format1, out iCharactersFitted, out iLinesFitted);
    
                if (strPrintText.Length == 0)
                {
                    e.Cancel = true;
                    return;
                }
                if (iLinesFitted > 12)
                {
                    MessageBox.Show("Too many lines in richTextBox1.\nPlease reduce text entered.");
                    e.Cancel = true;
                    return;
                }
    
                g.DrawString(strPrintText, printFont1, Brushes.Black, rectfText, format1);
                g.DrawString("iLinesFilled = Lines in the rectangle: " + iLinesFitted.ToString(), printFont1, Brushes.Black,
                  rectfText.X, rectfText.Height + rectfText.Y);
                g.DrawString("iCharactersFitted = Characters in the rectangle: " + iCharactersFitted.ToString(), printFont1, Brushes.Black,
                  rectfText.X, rectfText.Height + rectfText.Y + printFont1.Height);
            }
    
           
    
            private void cmdPrintPreview_Click(object sender, EventArgs e)
            {
                printPreviewDialog1.ShowDialog();
            }
    
            private void printDocument1_BeginPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
            {
                //      strPrintText = richTextBox1.Text;
            }
    
        }
    }
