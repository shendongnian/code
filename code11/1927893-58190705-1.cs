    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using System.Data;
    using System.IO;
    
    namespace iTextBarcodes_58190058
    {
        class Program
        {
            static void Main(string[] args)
            {
                doit();
            }
    
            private static void doit()
            {
                string savepath = "M:\\StackOverflowQuestionsAndAnswers\\iTextBarcodes_58190058\\iTextBarcodes_58190058\\bin\\Debug\\codes.pdf";
                string barcode = "blahlblahblah";
                string price = "0.95";
                string description = "more blah blah";
                //Document doc = new Document(new iTextSharp.text.Rectangle(25, 11), 5, 8, 1, 1);
                Document doc = new Document();
                int count = 20;
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(savepath, FileMode.Create));
                doc.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Price");
                dt.Columns.Add("Des");
                for (int i = 0; i < count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = barcode  + " " + i;
                    row["Price"] = (double.Parse(price) + i).ToString();
                    row["Des"] = description + " " + i;
                    dt.Rows.Add(row);
                }
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    doc.Add(new Paragraph("Aaraiz"));
                    doc.Add(new Paragraph("Description: " + dt.Rows[i]["Price"].ToString()));
    
                    PdfContentByte cb = writer.DirectContent;
                    Barcode128 bc = new Barcode128();
                    bc.TextAlignment = Element.ALIGN_CENTER;
                    bc.Font = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                    bc.Code = dt.Rows[i]["ID"].ToString();
                    bc.AltText = "Code: " + dt.Rows[i]["ID"].ToString() + "  Price: " + dt.Rows[i]["Price"].ToString();
                    bc.StartStopText = false;
                    bc.CodeType = iTextSharp.text.pdf.Barcode128.EAN13;
                    bc.Extended = true;
                    iTextSharp.text.Image img = bc.CreateImageWithBarcode(cb, iTextSharp.text.BaseColor.BLACK, iTextSharp.text.BaseColor.BLACK);
                    cb.SetTextMatrix(1.5f, 3.0f);
                    img.ScaleToFit(120, 25);
                    doc.Add(img);
    
    
                }
                doc.Close();
                System.Diagnostics.Process.Start(savepath);
            }
        }
    }
