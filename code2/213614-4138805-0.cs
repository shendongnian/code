    using (TextWriter writer = File.CreateText()) // Or AppendText
    {
        writer.WriteLine("First name: {0}", firstNameInput.Text);
        writer.WriteLine("Last name: {0}", lastNameInput.Text);
        writer.WriteLine("Phone number: {0}", phoneInput.Text);
        writer.WriteLine("Date of birth: {0}", birthInput.Text);
    }
