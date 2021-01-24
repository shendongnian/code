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
                string price = "12.95";
                string description = "more blah blah";
                //Document doc = new Document(new iTextSharp.text.Rectangle(25, 11), 5, 8, 1, 1);
                Document doc = new Document();
                int count = 10;
                PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(savepath, FileMode.Create));
                doc.Open();
                DataTable dt = new DataTable();
                dt.Columns.Add("ID");
                dt.Columns.Add("Price");
                dt.Columns.Add("Des");
                for (int i = 0; i < count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["ID"] = barcode;
                    row["Price"] = price;
                    row["Des"] = description;
                    dt.Rows.Add(row);
                }
    
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Paragraph p = new Paragraph();
                    p.Add("Aaraiz");
                    p.Add("Description: " + dt.Rows[i]["Price"].ToString());
                    doc.Add(p);
    
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
                    img.ScaleToFit(60, 5);
                    doc.Add(img);
    
    
                }
                doc.Close();
                System.Diagnostics.Process.Start(savepath);
            }
        }
    }
