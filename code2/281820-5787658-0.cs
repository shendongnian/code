    class Program
    {
        static void Main()
        {
            var controlType = typeof(Control);
            var controls = controlType
                .Assembly
                .GetTypes()
                .Where(t => controlType.IsAssignableFrom(t) && 
                            t.Namespace == "System.Windows.Forms"
                );
            foreach (var control in controls)
            {
                Console.WriteLine(control);
            }
        }
    }
