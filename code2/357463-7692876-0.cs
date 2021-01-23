    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    
    namespace NESCTC.Components.Pdf
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
    
            public PdfDocumentMerger(string[] fileNames) : this()
            {
                //add the file names array to the source file list
                sourceFileList.AddRange(fileNames.AsEnumerable<string>());
            }
    
            #endregion
    
            #region properties
    
            public List<string> SourceFiles
            {
                get
                {
                    return sourceFileList;
                }
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
                    int SourceIndex = 0;
                    PdfReader Reader = new PdfReader(sourceFileList[SourceIndex]);
    
                    int SourceFilePageCount = Reader.NumberOfPages;
    
                    Document Doc = new Document(Reader.GetPageSizeWithRotation(1));
                    PdfWriter Writer = PdfWriter.GetInstance(Doc, new FileStream(DestinationFileName, FileMode.Create));
                    Doc.Open();
    
                    PdfImportedPage Page;
                    PdfContentByte ContentByte = Writer.DirectContent;                
    
                    int Rotation;
                    while (SourceIndex < sourceFileList.Count)
                    {
                        int PageIndex = 0;
                        while (PageIndex < SourceFilePageCount)
                        {
                            PageIndex++;
                            Doc.SetPageSize(Reader.GetPageSizeWithRotation(PageIndex));
                            Doc.NewPage();
    
                            Page = Writer.GetImportedPage(Reader, PageIndex);
                            Rotation = Reader.GetPageRotation(PageIndex);
    
                            if (Rotation.Equals(90 | 270))
                            {
                                ContentByte.AddTemplate(Page, 0, -1f, 1f, 0, 0, Reader.GetPageSizeWithRotation(PageIndex).Height);
                            }                        
                            else
                            {
                                ContentByte.AddTemplate(Page, 1f, 0, 0, 1f, 0, 0);
                            }                       
                        }
    
                        SourceIndex++;
                        if (SourceIndex < sourceFileList.Count)
                        {
                            Reader = new PdfReader(sourceFileList[SourceIndex]);
                            SourceFilePageCount = Reader.NumberOfPages;
                        }
                    }
                    
                    Doc.Close();
                }
                catch
                {
                    throw;
                }
    
                return destinationFileName;
            }
        }
    }
