    [TestMethod]
    public void testVisio()
    {
        Microsoft.Office.Interop.Visio.Application visioApp = null;
        try
        {
            //Create a new instance of Visio
            visioApp = new Microsoft.Office.Interop.Visio.Application();
            // Show Visio
            visioApp.Visible = true;
            foreach (Page page in visioApp.ActiveDocument.Pages)
            {
                foreach (Shape shape in page.Shapes)
                {
                    Console.WriteLine(String.Format("Page {0}: Shape-Name: {1}", page.Name, shape.Name));
                }
            }
        }
        finally
        {
            //Close started application again
            visioApp.Quit();
            Marshal.ReleaseComObject(visioApp);
            visioApp = null;
        }
    }
