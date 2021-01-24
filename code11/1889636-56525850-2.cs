    private void button1_Click(object sender, EventArgs e)
    {
        string tmpDir = Path.GetTempPath();
        string pathToFile = Path.Combine(tmpDir, "test123.txt");
		if (File.Exists(pathToFile))
        {
            File.Delete(pathToFile);
        }
        //Print completed where you want
    }
