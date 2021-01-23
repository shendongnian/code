    public class GuardedPrinter : IPrinter
    {
        private readonly IPrinter realPrinter;
        private readonly IPrinter nullPrinter;
        // more fields and initialization omitted for brevety...
        public PrintResult Print()
        {
            if (this.licence.IsEnabled)
            {
                return this.realPrinter.Print();
            }
            
            return this.nullPrinter.Print();
        }
    }
