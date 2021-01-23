    using System;
    using KeithRull.Utilities.OfficeInterop;
    namespace WordDocMerge2
    {
      class Program
      {
        static void Main(string[] args)
        {
            try
            {
                string document1 = @"D:\Visual Studio Projects\31.docx";
                string document2 = @"D:\Visual Studio Projects\33.docx";
                string document3 = @"D:\Visual Studio Projects\32.docx";
                string[] documentsToMerge = { document1, document2, document3 };
                string outputFileName = String.Format("D:\\Visual Studio Projects\\{0}.docx", Guid.NewGuid( ));
                MsWord.Merge(documentsToMerge, outputFileName, true);
            }
            catch (Exception ex)
            {
                //messageLabel.Text = ex.Message;
            }
        }
    }
    }
