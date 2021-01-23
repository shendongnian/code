    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Windows.Forms;
    
    namespace BarcodeTest
    {
        class BarcodePrinter
        {
            public BarcodePrinter(List<DocumentType> type, string number)
            {
                docType = type;
                flightNumber = number;
            }
    
            //Attributes
            private List<DocumentType> docType = new List<DocumentType>();
            private string flightNumber;
    
            //helper variables
            string docTypeNumber;
            string docTypeDescription;
            int pageNumber = 1;
            int numberOfPages;
            Font barcodeFont = new Font("3 of 9 Barcode", 36);
            Font printFont = new Font("Arial", 24);
            int i = 0;
    
            
            
                
    
            public void Print()
            {
                
                numberOfPages = docType.Count;  //# of List elements = # of pages
                    
                            
                PrintDocument pd = new PrintDocument();
                
                pd.PrintPage += new PrintPageEventHandler(this.pd_PrintPage);
    
                
    
    #if DEBUG
                PrintPreviewDialog printPreview = new PrintPreviewDialog();
                printPreview.Document = pd;
                printPreview.Show();
    #else 
    			pd.Print();
    #endif
          
                                 
            }// end Print() method
    
            
            public void pd_PrintPage(Object sender, PrintPageEventArgs e)
            {
    
                docTypeNumber = docType[i].DocumentTypeNumber;  // This is a get/set Property
                docTypeDescription = docType[i].DocumentDescription; // This is a get/set Property
    
                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Center;
                stringFormat.LineAlignment = StringAlignment.Center;
    
               
                Graphics g = e.Graphics;
                e.Graphics.PageUnit = GraphicsUnit.Inch;
    
                Brush br = new SolidBrush(Color.Black);
                RectangleF rec1 = new RectangleF(.9375f, 0, 6, 1);
                RectangleF rec2 = new RectangleF(1.9375f, .5f, 4, 1);
                RectangleF rec3 = new RectangleF(1.9375f, 1f, 4, 1);
                RectangleF rec4 = new RectangleF(.9375f, 2, 6, 1);
                RectangleF rec5 = new RectangleF(1.9375f, 2.5f, 4, 1);
                g.DrawString("Air - " + docTypeDescription, printFont, br, rec1, stringFormat);
    // '*' Must Preceed and Follow Information for a bar code to be scannable
                g.DrawString("*" + docTypeNumber + "*", barcodeFont, br, rec2, stringFormat);
                g.DrawString(docTypeNumber, printFont, br, rec3, stringFormat);
    
    // '*' Must Preceed and Follow Information for a bar code to be scannable
                g.DrawString("*" + flightNumber + "*", barcodeFont, br, rec4, stringFormat);
                g.DrawString(flightNumber, printFont, br, rec5, stringFormat);
                
               
    
                if (pageNumber < numberOfPages)
                {
                    e.HasMorePages = true;
                    i++;
                    pageNumber++;
    
                }
                else
                {
                    e.HasMorePages = false;
                }
           
            }//end pd_PrintPage Method
    
            
        }//end BarcodePrinter Class
    }//end namespace
