    class Program
    {
        static public int Convert<T>(ICollection<T> value, Type targetType, object parameter, CultureInfo culture)        {
            return value.Count;
        }
    
        static void Main(string[] args)
        {
            Dictionary<int, string> di = new Dictionary<int,string>();
            di.Add(1, "One");
            di.Add(2, "Two");
            di.Add(3, "Three");
            Console.WriteLine("Dictionary count: {0}", di.Count);
            Console.WriteLine("Dictionary Convert: {0}", Convert(di, null, null, null));
    
            ObservableCollection<double> oc = new ObservableCollection<double>();
            oc.Add(1.0);
            oc.Add(2.0);
            oc.Add(3.0);
            oc.Add(4.0);
            Console.WriteLine("ObservableCollection Count: {0}", oc.Count);
            Console.WriteLine("ObservableCollection Convert: {0}", Convert(oc, null, null, null));
    
            List<string> li = new List<string>();
            li.Add("One");
            li.Add("Two");
            li.Add("Three");
            li.Add("Four");
            li.Add("Five");
            Console.WriteLine("List Count: {0}", li.Count);
            Console.WriteLine("List Convert: {0}", Convert(li, null, null, null));
    
            Console.ReadLine();
        }
    }
