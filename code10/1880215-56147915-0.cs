     [Test]
        public void SaveContentInsideFrame()
        {
            
            string ID = "7";
            string valueToBeSet = "TestContent";
            var body = Go.To<DocumentsPage>().
               Documents.Rows[x => x.Dokument_ID == ID].Edit().
               // Refresh page so the content can be visible
               RefreshPage();
               //Execute script for changing content
               AtataContext.Current.Driver.ExecuteScript("CKEDITOR.instances.Details_0__Content.setData('" + valueToBeSet + "')");              
               body.
               // Click on Save button
               Save();
        }
