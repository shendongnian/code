    abstract class Printer
    {
        public void Debug()
        {
            foreach (var field in GetType().GetFields())
            {
                Console.WriteLine(field.GetValue(this));
            }       
        }
    }
