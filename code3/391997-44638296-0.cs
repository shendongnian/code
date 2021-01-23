    using System.IO;
    using System.Diagnostics;
        private void OpenPdfButtonClick(object sender, EventArgs e)
        {
            //Convert The resource Data into Byte[] 
            byte[] PDF = Properties.Resources.ReferenceGuide;
            
            MemoryStream ms = new MemoryStream(PDF);
            
            //Create PDF File From Binary of resources folders helpFile.pdf
            FileStream f = new FileStream("helpFile.pdf", FileMode.OpenOrCreate);
 
            //Write Bytes into Our Created helpFile.pdf
            ms.WriteTo(f);
            f.Close();
            ms.Close();
            // Finally Show the Created PDF from resources 
            Process.Start("helpFile.pdf");
        }
