    public class InvoiceTextExtraction
    {
        private List<string> _contentList;
    
        public void GetInvoiceTotal()
        {
            _contentList = new List<string>();
            CreatePdfContent(@"C:\temp\Invoice1.pdf");
    
            var index = _contentList.FindIndex(e => e == "INVOICE") + 1;
            int.TryParse(_contentList[index], out var value);
            Console.WriteLine(value);
        }
    
    
        public void CreatePdfContent(string filePath)
        {
            using (var file = new File(filePath))
            {
                var document = file.Document;
    
                foreach (var page in document.Pages)
                {
                    Extract(new ContentScanner(page));
                }
            }
        }
    
        private void Extract(ContentScanner level)
        {
            if (level == null)
                return;
    
            while (level.MoveNext())
            {
                var content = level.Current;
                switch (content)
                {
                    case ShowText text:
                    {
                        var font = level.State.Font;
                        _contentList.Add(font.Decode(text.Text));
                        break;
                    }
                    case Text _:
                    case ContainerObject _:
                        Extract(level.ChildLevel);
                        break;
                }
            }
        }
    }
