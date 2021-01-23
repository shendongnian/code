            string FirstPanda = "C:\\FirstPanda.txt";
            string SecondPanda = "C:\\SecondPanda.txt";
            StringWriter writer = new StringWriter(); // System.IO;
            System.IO.StreamReader file;
            if (firstCheckBox.IsChecked)  
            {
                if (File.Exists(FirstPanda))
                {
                    file = new System.IO.StreamReader(FirstPanda);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("Number of files infected"))
                        {
                            writer.WriteLine("Panda " + line);
                        }
                    }
                    file.Close();
                    System.IO.File.Delete(FirstPanda);
                }
            }
            if (secondCheckBox.IsChecked)
            {
                if (File.Exists(SecondPanda))
                {
                    file = new StreamReader(SecondPanda);
                    while ((line = file.ReadLine()) != null)
                    {
                        if (line.Contains("Number of files infected"))
                        {
                            writer.WriteLine("Panda " + line);
                        }
                    }
                    file.Close();
                    System.IO.File.Delete(SecondPanda);
                }
            }
            MessageBox.Show(writer.ToString());
