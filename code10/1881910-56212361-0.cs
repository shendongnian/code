    class Program {
        static void Main(string[] args) {
            //Initialize scenario
            var item1 = new ExportItem();
            var item2 = new ExportItem();
            var item3 = new ExportItem();
            item1.Container["ID"] = Guid.NewGuid();
            item1.Container["Name"] = "John Smith";
            item1.Container["DateOfBirth"] = new DateTime(2002, 10, 10);
            item2.Container["Name"] = "Alice";
            item2.Container["DateOfBirth"] = new DateTime(2004, 10, 20);
            item2.Container["ID"] = Int32.MinValue;
            item3.Container["ID"] = new Object();
            item3.Container["Name"] = "Bob";
            item3.Container["DateOfBirth"] = "Invalid Date";
            List<ExportItem> myExportItems = new List<ExportItem>() { item1, item2, item3 };
            //Initialize filter (older than 12 years)
            Int32 myAge = 12;
            DateTime myAgeLimit = DateTime.Today.AddYears(myAge * -1);
            Predicate<KeyValuePair<String, Object>> myFilter = (x => (x.Key == "DateOfBirth") && (x.Value is DateTime) && ((DateTime)x.Value) < myAgeLimit);
            //Filter the according items
            var myResult = (from e in myExportItems from e2 in e.Container where myFilter(e2) select e);
            //Execute something 
            Console.Out.WriteLine($"Older than {myAge} years old:");
            foreach (var myExportItem in myResult) {
                var myContainer = myExportItem.Container;
                String myID = "unknown";
                String myName = "unknown";
                String myDateOfBirth = ((DateTime)myContainer["DateOfBirth"]).ToString("yyyy-MM-dd");
                try {
                    myID = ((Guid)myContainer["ID"]).ToString("D");
                } catch { }
                try {
                    myName = ((String)myContainer["Name"]);
                } catch { }
                Console.WriteLine($"myID={myID}");
                Console.WriteLine($"myID={myName}");
                Console.WriteLine($"myID={myDateOfBirth}");
                Console.WriteLine();
            }
        }
    }
    public class ExportItem {
        public Dictionary<string, object> Container { get; set; }
        public ExportItem() {
            Container = new Dictionary<string, object>();
        }
    }
