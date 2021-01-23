    public void Logger(String lines)
    {
        // Write the string to a file.append mode is enabled so that the log lines get appended to  test.txt than wiping content and writing the log
        System.IO.StreamWriter file = new System.IO.StreamWriter("c:\\test.txt",true);
        file.WriteLine(lines);
    
        file.Close();
    }
