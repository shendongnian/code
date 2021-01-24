    public void Handle_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!(sender is Entry label))
        {
            return;
        }
    
        if (e.OldTextValue != null && e.NewTextValue.Length < e.OldTextValue.Length)
        {
            Console.WriteLine("Char deleted");
        }
    }
