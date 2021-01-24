    private void buttonSave_Click(object sender, EventArgs e)
    {
        if (listBoxPeople.SelectedIndex == 0)
        {
            for (int i = 0; i < size; i++)
            {
                firstnames[i] = textBoxes[i].Text;
            }                
        }
        //...
