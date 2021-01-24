            public static string PathDomain { get; set; }
            public static void Main(string[] args)
            {
    
                PathDomain = AppDomain.CurrentDomain.RelativeSearchPath ?? AppDomain.CurrentDomain.BaseDirectory;
                CreateWebHostBuilder(args).Build().Run();
                Console.WriteLine("Api started :)");
    
            }
