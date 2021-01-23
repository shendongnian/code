    public abstract class InputPage : System.Web.UI.Page
    {
      protected override OnLoad(EventArgs e)
      {
         var master = this.Master as TwoPanelMaster;
         master.GetSubmitButton().OnClick += Submit_Click();
      }
      
      private void Submit_Click(object sender, EventArgs e)
      {
         ValidateInput();
      }
    
      protected virtual void ValidateInput()
      {
         // do some common code (if any)
         string message;
         if (OnValidateInput(out message))
         {
            // validation succesful, show success message
            var master = this.Master as TwoPanelMaster;
            master.ShowMessage(message); // this method should hide the input panel and display message panel.
         }
      }
    
      // pages should provide implementation of this method
      protected abstract bool OnValidateInput(out string successMessage);
      
    }
