    // Program.cs
    class Program
    {
    
        static IEnumerable<Calib> MapItem(IEnumerable<XElement> elements)
        {
            return elements.Select(x => new Calib
            {
                Max = x.Attribute("Max").Value,
                Min = x.Attribute("Min").Value
            });
        }
    
        static void Walk(XDocument doc)
        {
            var xitems = MapItem(doc.Descendants("XaxisCalib"));
            xitems.Iter(x => Console.WriteLine("(XaxisCalib) X: Min = {0} | Max = {1}", x.Min, x.Max));
    
            var yitems = MapItem(doc.Descendants("YAxisCalib"));
            yitems.Iter(x => Console.WriteLine("(YaxisCalib) Y: Min = {0} | Max = {1}", x.Min, x.Max));
    
            var zitems = MapItem(doc.Descendants("ZAxisCalib"));
            zitems.Iter(x => Console.WriteLine("(ZaxisCalib) Z: Min = {0} | Max = {1}", x.Min, x.Max));
        }
    
        static void Main(string[] args)
        {
            const string path = @"C:\stuff";
            Parallel.ForEach(Directory.EnumerateFiles(path, "*.xml"), x => Walk(XDocument.Load(x)));
        }
    }
    
    // Exts.cs
    public static class Exts
    {
        public static void Iter<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }
    }
    
    // Calib.cs
    public class Calib
    {
        public string Max { get; set; }
        public string Min { get; set; }
    }
