    int counter = 0;
    string line;
    using (System.IO.StreamReader file = new System.IO.StreamReader("Sav1.txt"))
    {
        while ((line = file.ReadLine()) != null)
        {
            if (counter == 0)
            {
                richTextBox1.Items.Add(line);
            }
            counter++;
        }
    }
