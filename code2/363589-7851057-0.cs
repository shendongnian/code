    public static void Maker()
    {
      string basename = "log";
      string extention = ".txt";
      string finalname = "log.txt";
      using (StreamWriter writer = new StreamWriter(workingDIR + finalname, true))
      {
           finalname = basename + extention;
           for (int i = 1; i < 300; i++)
           {
                finalname = basename + i + extention;
           }
      }
    }
