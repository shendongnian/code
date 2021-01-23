    using System;
    using Word = Microsoft.Office.Interop.Word;
    using System.Configuration;
    namespace KeithRull.Utilities.OfficeInterop
    {
      public class MsWord
      {
        /// <summary>
        /// This is the default Word Document Template file. I suggest that you point this to the location
        /// of your Ms Office Normal.dot file which is usually located in your Ms Office Templates folder.
        /// If it does not exist, what you could do is create an empty word document and save it as Normal.dot.
        /// </summary>
        private static string defaultWordDocumentTemplate = @"Normal.dot";
        /// <summary>
        /// A function that merges Microsoft Word Documents that uses the default template
        /// </summary>
        /// <param name="filesToMerge">An array of files that we want to merge</param>
        /// <param name="outputFilename">The filename of the merged document</param>
        /// <param name="insertPageBreaks">Set to true if you want to have page breaks inserted after each document</param>
        public static void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks)
        {
            Merge(filesToMerge, outputFilename, insertPageBreaks, defaultWordDocumentTemplate);
        }
        /// <summary>
        /// A function that merges Microsoft Word Documents that uses a template specified by the user
        /// </summary>
        /// <param name="filesToMerge">An array of files that we want to merge</param>
        /// <param name="outputFilename">The filename of the merged document</param>
        /// <param name="insertPageBreaks">Set to true if you want to have page breaks inserted after each document</param>
        /// <param name="documentTemplate">The word document you want to use to serve as the template</param>
        public static void Merge(string[] filesToMerge, string outputFilename, bool insertPageBreaks, string documentTemplate)
        {
            object defaultTemplate = documentTemplate;
            object missing = System.Type.Missing;
            object pageBreak = Word.WdBreakType.wdSectionBreakNextPage;
            object outputFile = outputFilename;
            // Create  a new Word application
            Word._Application wordApplication = new Word.Application( );
            try
            {
                // Create a new file based on our template
                Word.Document wordDocument = wordApplication.Documents.Add(
                                              ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);
                // Make a Word selection object.
                Word.Selection selection = wordApplication.Selection;
                //Count the number of documents to insert;
                int documentCount = filesToMerge.Length;
                //A counter that signals that we shoudn't insert a page break at the end of document.
                int breakStop = 0;
                // Loop thru each of the Word documents
                foreach (string file in filesToMerge)
                {
                    breakStop++;
                    // Insert the files to our template
                    selection.InsertFile(
                                                file
                                            , ref missing
                                            , ref missing
                                            , ref missing
                                            , ref missing);
                    //Do we want page breaks added after each documents?
                    if (insertPageBreaks && breakStop != documentCount)
                    {
                        selection.InsertBreak(ref pageBreak);
                    }
                }
                // Save the document to it's output file.
                wordDocument.SaveAs(
                                ref outputFile
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing
                            , ref missing);
                // Clean up!
                wordDocument = null;
            }
            catch (Exception ex)
            {
                //I didn't include a default error handler so i'm just throwing the error
                throw ex;
            }
            finally
            {
                // Finally, Close our Word application
                wordApplication.Quit(ref missing, ref missing, ref missing);
            }
        }
    }
    }
