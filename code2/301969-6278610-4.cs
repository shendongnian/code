    private void button1_Click(object sender, EventArgs e)
    {
        string[] path = {"C:\\Test", "C:\\TestABC", "C:\\Test1\\123", "C:\\Test2\\145"}; //all the directories
        for(int i = 0; i < path.Length; i++)
        {
            Directory.CreateDirectory(path[i]);
        }
    }
