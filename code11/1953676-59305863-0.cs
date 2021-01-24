    using (System.IO.StreamWriter writer = new System.IO.StreamWriter("newfile.csv"))
     {
         foreach (string line in System.IO.File.ReadAllLines("oldfile.csv"))
         {
             string[] items = line.Split(new[] { ';' });
     
             string newDateFormat = DateTime.ParseExact(items[1], "dd.MM.yy", System.Globalization.CultureInfo.CurrentCulture).ToString("yyyy-MM-dd");
     
             writer.Write(items[0]);
             writer.Write(';');
             writer.Write(newDateFormat);
             writer.Write(';');
             writer.Write(items[2]);
             writer.Write(';');
             writer.WriteLine();
         }
     }
