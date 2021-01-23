    public MessageBoxCustom(string Message, string Title)
    {
        InitialiseComponent();//this comes first to load Front End
        textblock1.Text = Title;
        textblock2.Text = Message;
    }
    Just position your TextBlocks where you want them to be displayed in XAML
    From your Main Window you can call that message box like this
    private void Button_Click()
    {
        MessageBoxCustom msg = new MessageBoxCustom("Your message here","Your title her");
        msg.ShowDialog();
    }
    
