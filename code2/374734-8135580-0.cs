    public bool SaveClicked{get; set;}
    
    private void btnSave_Click(object sender, EventArgs e)
    {
         try 
         {
             //do your stuff
         }
         catch(Exception ex)
         {
          
         }
         finally
         {
            SaveClicked = true;
         }
    }
