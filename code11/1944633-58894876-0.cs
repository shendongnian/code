    public string ggggg(string Names)
    {
        string[] strArray = Regex.Split(Names, " - ");
        return Convert.ToString(strArray[0]);
    }
    
    
    public async void BtnNames_Click(object sender, EventArgs e)
    {
        var names = combo.Text;
        var port = await Task.Run(() => ggggg(names));
    
        if (port == "")
        {
            MessageBox.Show("Please Selcet ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Done", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
