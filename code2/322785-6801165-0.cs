    UploadManager manager = new UploadExcel ();  // note the type of manager, no var
    ...
    manager.Validate();  // calls the Excel or the Access override
    public abstract class UploadManager
    {
        // SaveFile, DeleteFile
    
        public abstract bool Validate();
    }
    
    
    public class UploadExcel : UploadManager
    {
          public override bool Validate()
          {
              // ...
              return ValidateWorksheet();
          }
    
          private bool ValidateWorksheet()
          {
             //Implement
          }
    }
