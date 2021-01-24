    protected void ButtonSave_Click(object sender, EventArgs e)
    {
         // Anyone has subscribed to the event?
         if(DataReady != null)
         {
             ButtonData btn = new ButtonData();
             // Change these GetXXXXValue with the appropriate code 
             // that extracts the info from the ScreenLocation UI.
             btn.ID = GetTheIDValue();
             btn.Name = GetTheNameValue();
             btn.Rect = GetTheRectValue();
             // Send the info to the interested parties.
             DataReady(btn);
         }
    }
