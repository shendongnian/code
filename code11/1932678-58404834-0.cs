            // create a new document
            PdfDocument document = new PdfDocument();
            // crate a page description
            PageInfo pageInfo = new PageInfo.Builder(100, 100, 1).Create();
            // start a page
            Page page = document.StartPage(pageInfo);
            // draw something on the page
            View content = FindViewById(Android.Resource.Id.Content);
            content.Draw(page.Canvas);
            // finish the page
            document.FinishPage(page);
            // add more pages
            // write the document content
            FileStream fileOutputStream = new FileStream(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), FileMode.CreateNew);
            document.WriteTo(fileOutputStream);
            // close the document
            document.Close();
