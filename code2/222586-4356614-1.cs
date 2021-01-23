    private void buttonSave_Click(object sender, EventArgs e)
    {
        Person p = new Person(textBoxName.Text,
                              textBoxAge.Text,
                              textBoxCity.Text);
        p.SerializeToFile();
    }
