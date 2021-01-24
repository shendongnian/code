    public static class MyExtensions
    {
        public static bool ContainsInsensitive(this String str, string txt)
        {
            return str.IndexOf(txt, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
    private void txtSearch_KeyPress_1(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)13)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                var query = from o in App.Phonebook
                            where (o.PhoneNumber.ContainsInsensitive(txtSearch.Text) || o.Department.ContainsInsensitive(txtSearch.Text) || o.Name.ContainsInsensitive(txtSearch.Text) || o.Email.ContainsInsensitive(txtSearch.Text))
                                select o;
                dataGridView.DataSource = query.ToList();
            }
            else
                dataGridView.DataSource = phonebookBindingSource;
        }
    }
