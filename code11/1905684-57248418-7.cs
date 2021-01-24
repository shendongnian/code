     private void btnAdd_Click(object sender, EventArgs e)
     {
        Datalogger myself = new Datalogger
        {
            Record = currentData.Count + 1;
            IPaddress = textBox2.Text,
            Machinename = textBox8.Text,
            username = textBox4.Text,
            password = textBox3.Text,
            sourcefolder = textBox7.Text,
            destfolder = textBox6.Text,
            filextension = textBox5.Text,
        };
        currentData.Add(myself);
        string output = Newtonsoft.Json.JsonConvert.SerializeObject(currentData, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, output);
    }
