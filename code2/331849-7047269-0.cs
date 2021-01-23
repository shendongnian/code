     class Program
        {
            static void Main(string[] args)
            {
                Dummy dummy = new Dummy();
                PropertyInfo[] properties = dummy.GetType().GetProperties();
                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine(((DisplayAttribute)property.GetCustomAttributes(false).Where(x => x.GetType() == typeof(DisplayAttribute)).First()).Name);
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
