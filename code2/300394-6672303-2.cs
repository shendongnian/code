        OpenFileDialog ofd = new OpenFileDialog();
        if (ofd.ShowDialog() == DialogResult.OK)
        {
            PdfDocument _document = null;
            try
            {
                _document = PdfReader.Open(ofd.FileName, PdfDocumentOpenMode.Modify);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"FATAL");
                //do any cleanup and return
                return;
            }
            if (_document != null)
            {
                if (_document.AcroForm != null)
                {
                    MessageBox.Show("Acroform is object","SUCCEEDED");
                    //pass acroform to some function for processing
                    _document.Save(@"C:\temp\newcopy.pdf");
                }
                else
                {
                    MessageBox.Show("Acroform is null","FAILED");
                }
            }
            else
            {
                MessageBox.Show("Uknown error opening document","FAILED");
            }
        }
