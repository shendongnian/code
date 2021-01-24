    public void Handle_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(sender is Entry label))
        {
            return;
        }
    
        if (!string.IsNullOrEmpty(e.OldTextValue) && e.NewTextValue.Length < e.OldTextValue.Length)
        {
            Console.WriteLine("Char deleted");
        }
    }
