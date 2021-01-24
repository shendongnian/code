    private void comboBox1_TextUpdate(object sender, EventArgs e)
    {
        comboBox1.Items.Clear();
        listNew.Clear();
    
        foreach (var item in listOnit)
        {
            if (item.ToLower().Contains(this.comboBox1.Text.ToLower()))
            {
                listNew.Add(item);
            }
        }
        comboBox1.Items.AddRange(listNew.ToArray());
        comboBox1.SelectionStart = this.comboBox1.Text.Length;
        Cursor = Cursors.Default;
        comboBox1.DroppedDown = true;
    }
