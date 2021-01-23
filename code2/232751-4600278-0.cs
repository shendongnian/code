    using System;
    
    namespace Test
    {
        class SaveState
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }
    
        class SaveStateWithPi : SaveState
        {
            public double Pi
            {
                get { return Math.PI; }
            }
        }
    
        class Program
        {
            public static T CreateSavedState<T>(int width, int height)
                where T : SaveState, new()
            {
                return new T
                           {
                               Width = width,
                               Height = height
                           };
            }
    
            static void Main(string[] args)
            {
                SaveState state = CreateSavedState<SaveStateWithPi>(5, 10);
    
                Console.WriteLine("Width: {0}, Height: {1}", state.Width, state.Height);
            }
        }
    }
