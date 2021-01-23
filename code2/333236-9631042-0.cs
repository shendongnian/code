      internal interface IPercentage
        {
            int Percentage { get; set; }
        }
    
        internal interface IBase1 : IPercentage
        {
        }
    
        internal interface IBase2 : IPercentage
        {
        }
    
        internal interface IAllYourBase : IBase1, IBase2
        {
        }
    
        internal class AllYourBase : IAllYourBase
        {
            private int percentage;
    
            public int Percentage
            {
                get { return percentage; }
                set { percentage = value; }
            }
    
            void Foo()
            {
                IAllYourBase iayb = new AllYourBase();
                int percentage = iayb.Percentage; // Compiles now!!!
            }
        }
