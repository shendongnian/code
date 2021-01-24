C#
    private void button2_Click(object sender, EventArgs e)
    {
        string product22 = "{  'ID': '56',  'AOID': '747'}";
        string json = product22.Replace("'AOID'", "'BOID'");
        Console.WriteLine(json);
    }
Hope it helps.
