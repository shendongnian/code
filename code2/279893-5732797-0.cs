    //Registering:
    Messenger.Default.Register<IEnumerable<BookViewModel>>(this, true, fillSourceWith);
    Messenger.Default.Register<DisplayModeEnum>(this, ChangeMainTemplates);
    
    //with a specific "token"
    Messenger.Default.Register<object>(this, MessageTokens.ClearList, o => BookSource.Clear()); 
