        if ( ListBox.SelectedItem is SetCredentialsForAD item )
        {
            Console.WriteLine(item.DomaineName);
            Console.WriteLine(item.LoginName);
            Console.WriteLine(item.PassWord);
        }
