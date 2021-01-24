`
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
public IActionResult createPdf()
{
    string html = "";
    byte[] pdf = null;
    using(PdfDocument doc = new PdfDocument())
    {
        for(int i = 0; i < files.Length; i++)
        {
            html = "html content";
            
            Process p;
            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "...\\wkhtmltopdf.exe";
            psi.WorkingDirectory = "...\\wkhtmltopdf\\bin";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;
            psi.StandardOutputEncoding = System.Text.Encoding.UTF8;
            psi.Arguments = "-O landscape --footer-left qwe --footer-center [page]/[topage] --footer-right --footer-font-size 9 --no-stop-slow-scripts --zoom 0.8 --dpi 300 - - ";
            p = Process.Start(psi);
            using(StreamWriter stdin = new StreamWriter(p.StandardInput.BaseStream, Encoding.UTF8))
            {
                stdin.AutoFlush = true;
                stdin.Write(html);
            }
            byte[] buffer = new byte[32768];
            byte[] currentPdf = null;
            using(var ms = new MemoryStream())
            {
                while(true)
                {
                    int read = p.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length); 
                    if(read <= 0)
                    {
                        break;
                    }       
                    ms.Write(buffer, 0, read);
                 }
                 currentPdf = ms.ToArray();
             }
             p.StandardOutput.Close();
             p.WaitForExit(10000);
             p.Close();     
             MemoryStream currentPDF = new MemoryStream(currentPdf);
             // Merge separated pdfs into one
// Solves encoding errors   
System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
             using(PdfDocument pdfDoc = PdfReader.Open(currentPDF, PdfDocumentOpenMode.Import))
             {
                 for(int j = 0; j < pdfDoc.PageCount; j++)
                 {
                     doc.AddPage(pdfDoc.Pages[j]);
                 }
             }
             currentPDF.Close();
        }
        // Get merged pdfs as bytes
        MemoryStream rms = new MemoryStream();
        doc.Save(rms, false);
        pdf = rms.ToArray();
        rms.Close();
    }
    
    MemoryStream PDF = new MemoryStream(pdf);
    // Return PDF to browser
    return new FileStreamResult(PDF, "application/x-msdownload")
    {
        FileDownloadName = "mergedPdfs.pdf"
    }; 
}
`
