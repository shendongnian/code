    private void HardButton_Click(object sender, EventArgs e)
    {
        var hard1 = new List<int>();
        int counter = 0;
        using (StreamReader inFile = new StreamReader("h1.txt"))
        {
            string str = null;
            while ((str = inFile.ReadLine()) != null)
            {
                hard1.Add(Convert.ToInt32(str));
                counter++;
            }
        }
    ...
