    private void ButtonSubmit_Click(object sender, EventArgs e)
    {
        User user = new User(textBoxFirstName.Text, textBoxLastName.Text);
        _listBoxUsers.Items.Add(user);
        this.Close();
    }
