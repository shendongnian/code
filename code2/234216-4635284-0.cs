    using System;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.IO;
    using System.Drawing.Printing;
    
    namespace PrinterExample
    {
        public partial class Printer : Form
        {
            private string textToDisplay;
            private Font printFont;
            private StreamReader streamToPrint;
            private int mode;
           //mode 1 - Preview, 2 - Print
            public Printer(string textToDisplay,int mode)
            {
                this.textToDisplay = textToDisplay;
                this.mode = mode;
                InitializeComponent();
                PreviewPage();
    
            }
    
            internal void PreviewPage()
            {
                try
                {
                    streamToPrint = new StreamReader(new MemoryStream(Encoding.ASCII.GetBytes(textToDisplay)));
                    printFont = DefaultFont;
                    PrintDocument pd = new PrintDocument();
                    pd.PrintPage += new PrintPageEventHandler
                       (this.pd_PrintPage);
    
                    var ppd = new PrintPreviewDialog();
                    ppd.Document = pd;
    
                    if (mode == 1) ppd.Show();
                    if (mode == 2) pd.Print();
                }
                catch
                {
                    MessageBox.Show("Exception occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            private void pd_PrintPage(object sender, PrintPageEventArgs ev)
            {
                float linesPerPage = 0;
                float yPos = 0;
                int count = 0;
                float leftMargin = ev.MarginBounds.Left;
                float rightMargin = ev.MarginBounds.Right;
                float topMargin = ev.MarginBounds.Top;
                string line = null;
    
                // Calculate the number of lines per page.
                linesPerPage = ev.MarginBounds.Height /
                   printFont.GetHeight(ev.Graphics);
    
                float charsPerLine = (rightMargin - leftMargin) / (printFont.GetHeight(ev.Graphics)*0.65f);
    
                // Print each line of the file.
                while (count < linesPerPage &&
                   ((line = streamToPrint.ReadLine()) != null))
                {
                    string newLine = null;
                    int newLineCounter = 0;
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (i % (int)charsPerLine == 0)
                        {
                            newLine = line.Substring((int)charsPerLine * newLineCounter, (int)charsPerLine > (line.Length - (int)charsPerLine * newLineCounter) ? (line.Length - (int)charsPerLine * newLineCounter) : (int)charsPerLine); 
    
    
                            yPos = topMargin + (count *
                               printFont.GetHeight(ev.Graphics));
                            ev.Graphics.DrawString(newLine, printFont, Brushes.Black,
                               leftMargin, yPos, new StringFormat());
    
                            count++;
                            newLineCounter++;
                        }
                        
                    }
                    newLineCounter = 0;
                }
    
                // If more lines exist, print another page.
                if (line != null)
                    ev.HasMorePages = true;
                else
                    ev.HasMorePages = false;
            }
    
            private void Printer_FormClosing(object sender, FormClosingEventArgs e)
            {
                this.streamToPrint.Close();
            }
    
        }
