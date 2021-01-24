     private void btnModify_Click(object sender, EventArgs e)
     {
         int record = Convert.ToInt32(txtRecord.Text);
         DataLogger logger = currentData.FirstOrDefault(x => x.Record == record);
         if(logger != null)
         {
             // update logger with your textboxes data
             // Save everything
             string output = Newtonsoft.Json.JsonConvert.SerializeObject(currentData, Newtonsoft.Json.Formatting.Indented);
             File.WriteAllText(filePath, output);
         }
    }
