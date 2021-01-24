    bool listContainsItem = Listbox.Items.Any(item => item.Value == textboxValue);
    if(listContainsItem)
    {
      // ... item is in listbox, do your magic
    }
    else
    {
      // ... item is not in listbox, do some other magic 
    }
