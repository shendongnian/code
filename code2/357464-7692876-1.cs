    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace Components.Pdf
    {
        public class PdfDocumentMerger
        {
            private List<string> sourceFileList;
    
            #region constructors
    
            public PdfDocumentMerger()
            {
                //initialize the source file list
                sourceFileList = new List<string>();
            }
    
            public PdfDocumentMerger(params string[] fileNames) : this()
            {
                sourceFileList.AddRange(fileNames.AsEnumerable<string>());
            }
    
            #endregion
    
            /// <summary>
            /// Merges multiple PDF documents into one document
            /// </summary>
            /// <param name="DestinationFileName">The name and path to the merged document</param>
            /// <returns>The name and path to the merged document, if successful. Otherwise, the return value is an empty string</returns>
            public string Merge(string destinationFileName)
            {
                try
                {
                    int sourceIndex = 0;
                    PdfReader reader = new PdfReader(sourceFileList[sourceIndex]);
                    int sourceFilePageCount = reader.NumberOfPages;
    
                    Document doc = new Document(reader.GetPageSizeWithRotation(1));
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(destinationFileName, FileMode.Create));
                    doc.Open();
    
                    PdfImportedPage page;
                    PdfContentByte contentByte = writer.DirectContent;                
    
                    int rotation;
                    while (sourceIndex < sourceFileList.Count)
                    {
                        int pageIndex = 0;
                        while (pageIndex < sourceFilePageCount)
                        {
                            pageIndex++;
                            doc.SetPageSize(reader.GetPageSizeWithRotation(pageIndex));
                            doc.NewPage();
    
                            page = writer.GetImportedPage(reader, pageIndex);
                            rotation = reader.GetPageRotation(pageIndex);
    
                            if (rotation.Equals(90 | 270))
                                contentByte.AddTemplate(page, 0, -1f, 1f, 0, 0, reader.GetPageSizeWithRotation(pageIndex).Height);
                            else
                                contentByte.AddTemplate(page, 1f, 0, 0, 1f, 0, 0);                   
                        }
    
                        sourceIndex++;
                        if (sourceIndex < sourceFileList.Count)
                        {
                            reader = new PdfReader(sourceFileList[sourceIndex]);
                            sourceFilePageCount = reader.NumberOfPages;
                        }
                    }
                    
                    doc.Close();
                }
                catch
                {
                    throw;
                }
    
                return destinationFileName;
            }
        }
    }
