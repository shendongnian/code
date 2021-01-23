    private void button1_Click(object sender, EventArgs e)
    {
        string[] path = {...}; //all the directories
        for(int i = 0; i < path.Length; i++)
        {
            Directory.CreateDirectory(path[i]);
        }
    }
