    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listView1.SelectedItems.Count == 0) return;  // This line added will solve the problem
        textBox1.Text = people[listView1.SelectedItems[0].Index].Name; 
        textBox2.Text = people[listView1.SelectedItems[0].Index].Email;
        textBox3.Text = people[listView1.SelectedItems[0].Index].StreetAddress;
        textBox4.Text = people[listView1.SelectedItems[0].Index].AdditionalNotes;
        dateTimePicker1.Value = people[listView1.SelectedItems[0].Index].Birthday;
    }
