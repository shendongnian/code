         Visio.Application app = Globals.ThisAddIn.Application;
         Visio.Documents docs = app.Documents;
         ArrayList masterArray_0 = new ArrayList();
         ArrayList masterArray_1 = new ArrayList();
         Visio.Document doc_0 = docs[1];    // HERE IS THE MAIN POINT
         Visio.Document doc_1 = docs[2];    // HERE IS THE MAIN POINT
         Visio.Masters masters_0 = doc_0.Masters;
         Visio.Masters masters_1 = doc_1.Masters;
         foreach (Visio.Master master in masters_0)
         {
            masterArray_0.Add(master.NameU);   // THIS WILL CONTAIN DIAGRAM FIGURES
         }
         foreach (Visio.Master master in masters_1)
         {
            masterArray_1.Add(master.NameU);  // THIS WILL CONTAIN STENCIL FIGURES
         }
