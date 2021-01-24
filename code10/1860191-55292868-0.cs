        using (RichTextBox temphotfix = new RichTextBox())
        {
            temphotfix.Font = new Font(temphotfix.Font.Name, 14);
            System.Windows.Documents.TextRange range = new System.Windows.Documents.TextRange(omschrijving.Document.ContentStart, omschrijving.Document.ContentEnd);
            temphotfix.Text = oms;
            string temp = temphotfix.Rtf;
            byte[] byteArray = Encoding.ASCII.GetBytes(temp);
            using (MemoryStream stream = new MemoryStream(byteArray))
            {
                range.Load(stream, DataFormats.Rtf);
            }
            range = null;
            temp = null;
            byteArray = null;
            //temphotfix.Dispose();
            //stream.Dispose();
        }
