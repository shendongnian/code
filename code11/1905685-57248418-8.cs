     private void btnModify_Click(object sender, EventArgs e)
     {
         int record = Convert.ToInt32(txtRecord.Text);
         DataLogger logger = currentData.FirstOrDefault(x => x.Record == record);
         if(logger != null)
         {
             // update logger with your textboxes data
             logger.IPaddress = textBox2.Text;
             logger.Machinename = textBox8.Text;
             logger.username = textBox4.Text;
             logger.password = textBox3.Text;
             logger.sourcefolder = textBox7.Text;
             logger.destfolder = textBox6.Text;
             logger.filextension = textBox5.Text;
             // Save everything
             string output = Newtonsoft.Json.JsonConvert.SerializeObject(currentData, Newtonsoft.Json.Formatting.Indented);
             File.WriteAllText(filePath, output);
         }
    }
