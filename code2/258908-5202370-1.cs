     protected void btnSubmit_Click(object sender, EventArgs e) {
    
    using(TransactionScope scope = new TransactionScope())
    {
            if(SaveRecordsToDataDatabase())
            {
               If(UploadImage())
               {
        
                   showMessage("Save successfull",true);
               }
               else
               {
                  showMessage("Save failed",false);
               }
            }
            else
               {
                  showMessage("Save failed",false);
               }
        }
        scope.complete()
    }
