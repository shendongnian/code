         Microsoft.Office.Interop.Word.Application a = new Microsoft.Office.Interop.Word.Application ();
         Document d = a.Documents.Open 
            ( "afile.docx", 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing, 
              Type.Missing );
         d.ActiveWindow.Selection.WholeStory ();
         d.Activate ();
         foreach ( InlineShape isp in d.InlineShapes)
         {
            Console.WriteLine 
               ( "{0}: {1}, {2}", 
                 isp.OLEFormat.Object.Name, 
                 isp.OLEFormat.Object.Caption, 
                 isp.OLEFormat.Object.Value );
         }
