    List<Email> emails = new List<Email>();
    for (i = 0; i < bundle.MessageCount; i++)
    {
        email = bundle.GetEmail(i);
    	emails.Add(email);
    }
    dataGridView.ItemsSource = emails;
