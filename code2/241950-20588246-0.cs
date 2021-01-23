         var ms = new MemoryStream(bytes);
         using (WordprocessingDocument wd = WordprocessingDocument.Open(ms, true))
         {
            ...
            using (MemoryStream msData = new MemoryStream())
            {
               xdoc.Save(msData);
               msData.Position = 0;
               ourCxp.FeedData(msData); // Memory stream is not expandable.
