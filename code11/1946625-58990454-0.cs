    public static void ReadFile(int n, string logFile)
    {
        int lineCnt = 0;
        List <string> lastNLines= new List <string>();
        BackwardReader br = new BackwardReader(logFile);
        while (!br.SOF())
        {
            string line = br.Readline();
            if (lineCnt < n) lastNLines.Add(line);
            // else your implementation for other lines
            lineCnt++;
        }
    }
