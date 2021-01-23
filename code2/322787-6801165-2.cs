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
