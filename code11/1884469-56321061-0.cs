            string path = path\fileName.txt";
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                writer.WriteLine(text);
                writer.Close();
            }
        }
