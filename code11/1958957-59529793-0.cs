      public partial class MyForm : Form {
        ...
        // Unmanaged resources are allocated ...
        private readonly DataSet DS = new DataSet(); 
        ...
    
        protected override void Dispose(bool disposing) {
          base.Dispose(disposing);
    
          if (disposing) {
            // ... Unmanaged resources are freed
            if (DS != null) { // <- check for null : in order to be on the safe side
              DS.Dispose();
            }
          }
        }
        ...
      } 
