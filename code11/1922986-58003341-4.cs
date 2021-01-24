    private void Button_Clicked(object sender, EventArgs e)
    {
         var inputText = entry.Text; //get value from Entry
         MessagingCenter.Send<object, string>(this, "MessageKey", inputText);
    }
