    class Program
    {
        static void Main(string[] args)
        {
            string b = pdfText(Directory.GetCurrentDirectory()+ "/Net.pdf");
            string a= "kullan";
            int sonuc;
            sonuc = b.IndexOf(a,0, b.Length);
            if(sonuc==-1)
            {
                Console.WriteLine("not found");
            }
            else
            {
                Console.WriteLine("found from " + sonuc.ToString() + ". character");
            } 
        }
        public static string pdfText(string path)
        {
            PdfReader reader = new PdfReader(path);
            var dd = reader.GetPageContent(1);
            string text = string.Empty;
            for (int page = 1; page <= reader.NumberOfPages; page++)
            {
                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                text += PdfTextExtractor.GetTextFromPage(reader, page);
                
            }
            reader.Close();
            return text;
        }
    }
}
