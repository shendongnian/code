    public static void Maker()
    {
      string basename = "log";
      string extention = ".txt";
      string finalname = "log.txt";
      for (int i = 0; i < 300; i++)
      {
           using (StreamWriter writer = new StreamWriter(workingDIR + finalname, true))
           {
                if(i == 0)
                {
                    finalname = basename + extention;
                }
                else
                {
                    finalname = basename + i + extention;
                }
           }
      }
    }
