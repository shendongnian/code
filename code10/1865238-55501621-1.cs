    private void button1_Click(object sender, EventArgs e)
    {
        int[] hard1 = { };
        var lines = File.ReadAllLines("h1.txt");
        var lineWithoutEmptySpace = lines.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        hard1 = new Int32[lineWithoutEmptySpace.Length];
        for (var i = 0; i < lineWithoutEmptySpace.Length; i++)
        {
            hard1[i] = Convert.ToInt32(lineWithoutEmptySpace[i]);
        }
    }
