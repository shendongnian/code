    class Program
    {
        static void Main(string[] args)
        {
            Dummy dummy = new Dummy();
            PropertyInfo[] properties = dummy.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                IEnumerable<DisplayAttribute> displayAttributes = property.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>();
                foreach (DisplayAttribute displayAttribute in displayAttributes)
                {
                    Console.WriteLine("Property {0} has display name {1}", property.Name, displayAttribute.Name);
                }
            }
            Console.ReadLine();
        }
    }
    
    public class Dummy
    {
        [Display(Name = "Foo")]
        public string foo { get; set; }
    
        [Display(Name = "Bar")]
        public string bar { get; set; }
    }
