        /// <summary>
        /// Look through the Application's Document manager for a Document object with the given name.  If found return it,
        /// else open the drawing/Document and return it.
        /// </summary>
        /// <param name="name">The name to look for in the collection</param>
        /// <returns>An AutoCAD Document object.</returns>
        public static ACADApp.Document GetDocumentByName(string name)
        {
            try
            {
                foreach (ACADApp.Document doc in ACADApp.Application.DocumentManager)
                {
                    if (doc.Database.Filename.ToUpper() == name.ToUpper() || doc.Name.ToUpper() == name.ToUpper())
                    {
                        return doc;
                    }
                }
                return ACADApp.Application.DocumentManager.Open(name);
            }
            catch (System.Exception ex)
            {
                TBExceptionManager.HandleException(name, ex);
                return null;
            }
        }
