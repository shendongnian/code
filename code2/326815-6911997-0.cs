    [Flags]
            public enum SaveOption
            {
                Lines = 1,
                Circles = 2,
                Rectangles = 4
            }
    
            static void Main(string[] args)
            {
                SaveOption option = SaveOption.Circles | SaveOption.Rectangles;
    
                Console.WriteLine( option );
    
                option -= SaveOption.Circles;
    
                Console.WriteLine( option );
    
                option = option | SaveOption.Lines;
    
                Console.WriteLine(option);
            }
