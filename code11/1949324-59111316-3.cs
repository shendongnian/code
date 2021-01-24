        string line;
        using (System.IO.StreamReader file = new System.IO.StreamReader("Sav1.txt"))
        {
            if ((line = file.ReadLine()) != null)
            {
                richTextBox1.Items.Add(line);
            }
        }
    }
