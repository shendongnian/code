            //NotesConnectionDatabase is of type NotesDatabase.
            //A NotesNoteCollection represents a collection of Domino design 
            //and data elements in a database.
            NotesNoteCollection nnc;
            nnc = NotesConnectionDatabase.CreateNoteCollection(false);
            //All the different types of elements default to false.
            //Set SelectForms = true to add forms to the collection.
            nnc.SelectForms = true;
            nnc.BuildCollection();
            //...
            string nid = nnc.GetFirstNoteId();
            for (int i = 1; i <= nnc.Count; i++)
            {
                  NotesDocument doc = NotesConnectionDatabase.GetDocumentByID(nid);
                  doc.CopyToDatabase(ndDestination);
                  Console.WriteLine(nid + " copied");
                  swCopyForms.WriteLine(nid + " copied");
                  nid = nnc.GetNextNoteId(nid);
            }
