     private void button1_Click(object sender, EventArgs e)
     {
         string path = DayFuturesDestination + "\\" + txtSelectedDate.Text + ".txt";
         StreamWriter Strwriter = new StreamWriter(path);
         Strwriter.Write(textToAdd);
         Strwriter.Flush();
         Strwriter.Close();
         
         using (ZipFile zip = new ZipFile())
         {
             zip.AddFile(path);
             zip.Save(path + ".zip");
         }
     }
