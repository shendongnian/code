     WordC.Application wordApp = new WordC.Application();
                    //  create Word document object
                    WordC.Document aDoc = null;
                    object readOnly = false;
                     object isVisible = false;
                     wordApp.Visible = false;
                   //  wordApp.DisplayAlerts = false;
    //docFileName is the filename with complete path. ex c://test.doc
                     aDoc = wordApp.Documents.Open(docFileName, Type.Missing, ref readOnly, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, ref isVisible, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
    aDoc.Activate();
    aDoc.InlineShapes.AddPicture(imgFilename, Type.Missing, Type.Missing, Type.Missing);
               
                    aDoc.Save();
                    aDoc.Close(Type.Missing, Type.Missing, Type.Missing);
                    wordApp.Quit(Type.Missing, Type.Missing, Type.Missing);
