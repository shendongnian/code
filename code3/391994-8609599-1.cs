    private void button1_Click(object sender, EventArgs e)
       {
        string openPDFfile =  @"c:\temp\pdfName.pdf";
        ExtractResource("WindowsFormsApplication1.pdfName.pdf", openPDFfile);
        Process.Start(openPDFfile);
       }
    
         void ExtractResource( string resource, string path )
                {
                    Stream stream = GetType().Assembly.GetManifestResourceStream( resource );
                    byte[] bytes = new byte[(int)stream.Length];
                    stream.Read( bytes, 0, bytes.Length );
                    File.WriteAllBytes( path, bytes );
                }
