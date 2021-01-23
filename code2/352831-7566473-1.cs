    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();
            Control firstControl = new Control(manager);
            Control secondControl = new Control(manager);
            // No focus set yet.
            Console.WriteLine(string.Format("firstControl has focus? {0}",
                firstControl.HasFocus()));
            Console.WriteLine(string.Format("secondControl has focus? {0}",
                secondControl.HasFocus()));
            // Focus set to firstControl.
            manager.SetFocus(firstControl);
            Console.WriteLine(string.Format("firstControl has focus? {0}",
                firstControl.HasFocus()));
            Console.WriteLine(string.Format("secondControl has focus? {0}",
                secondControl.HasFocus()));
            // Focus set to firstControl.
            manager.SetFocus(secondControl);
            Console.WriteLine(string.Format("firstControl has focus? {0}",
                firstControl.HasFocus()));
            Console.WriteLine(string.Format("secondControl has focus? {0}",
                secondControl.HasFocus()));
        }
    }
