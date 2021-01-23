    delegate void StringParameterDelegate (string value);
    public void UpdateText(string textToUpdate)
    {
         if (InvokeRequired)
         {
            BeginInvoke(new StringParameterDelegate(UpdateText), new object[]{textToUpdate});
            return;
         }
         // Must be on the UI thread if we've got this far
         txtblah2.Text = textToUpdate;
     }
