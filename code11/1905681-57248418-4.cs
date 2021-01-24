     private void btnDelete_Click(object sender, EventArgs e)
     {
         int record = Convert.ToInt32(txtRecord.Text);
         DataLogger logger = currentData.FirstOrDefault(x => x.Record == record);
         if(logger != null)
         {
             currentData.Remove(logger);
             // Save everything
             string output = Newtonsoft.Json.JsonConvert.SerializeObject(currentData, Newtonsoft.Json.Formatting.Indented);
             File.WriteAllText(filePath, output);
         }
