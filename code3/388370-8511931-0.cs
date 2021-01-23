    foreach (string s in Directory.GetLogicalDrives())
    {
        if (list.Count == 0)
        {
            foreach (string f in Directory.EnumerateFiles(s, file, SerchOption.AllDirectories))
            {
                try
                {
                    textBox2.Text = f;
                    list.Add(f);
                }
                catch (System.Exception excpt)
                {
                    Console.WriteLine(excpt.Message);
                }
            }
        }
    }
