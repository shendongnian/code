     private void button1_Click(object sender, EventArgs e)
     {
         using (ZipFile zip = new ZipFile())
         {
             string path = DayFuturesDestination + "\\" + txtSelectedDate.Text + ".txt";
             StreamWriter Strwriter = new StreamWriter(path);
             Strwriter.Write(textToAdd);
             Strwriter.Flush();
             Strwriter.Close();
             zip.AddFile(path);
             zip.Save("MyZipFile.zip");
         }
     }
