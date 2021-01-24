    public static void Main(string[] args) 
    {
         Parser.Default.ParseArguments<Options>(args) 
                       .WithParsed(options => 
                        { httphelper.PostAsync(...).Result; 
                        } 
    }
