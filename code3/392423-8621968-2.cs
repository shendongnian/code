    private void On_BoxClicked(sender object, EventArgs e)
    {
         PopUpBox dialog = new PopUpBox();
         var result = PopUpBox.ShowDialog();
         if (result == true)
         {
              //process the result here accessing the properties that
              //are needed through the dialog object.
         }
    }
