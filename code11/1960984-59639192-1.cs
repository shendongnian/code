    Word.Application app = null;
    Word.Document doc = null;
    try {
      app = new Word.Application();
      //app.Visible = true;
      doc = app.Documents.Add();
      // do some stuff with the document…
      doc.SaveAs2(filename);
      MessageBox.Show("Document created successfully !");
    }
    catch (Exception e) {
      MessageBox.Show("ERROR: " + e.Message);
    }
    finally {
      if (doc != null) {
        doc.Close();
        Marshal.ReleaseComObject(doc);
      }
      if (app != null) {
        app.Quit();
        Marshal.ReleaseComObject(app);
      }
    }
