      public class XmlRepository2 
      { 
        public void CrudOp() 
        { 
            // DON'T call save 
        } 
       
        public MakeTransacedChanges(Action<XmlRepository2> makeChanges)
        {
            try{ 
                makeChanges(this);
                saveChanges();
            }
            catch (RepositoryException e) 
            {
               //revert changes
            }
        }
    
        private void saveChanges() 
        { 
            xDocument.Save(path); 
        }
      }
     
