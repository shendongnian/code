        public class Entry {
            public string s = "N/A";
        }
        List<Entry> lis = new List<Entry> { new Entry(), new Entry(), new Entry(), new Entry() };
        public void MainFoo() {
            lis.ForEach( (Entry element) => {
                ChangeElement(ref element);      
            } );
            Console.WriteLine(lis[0].s); // Will print Changed from within method
        } 
        public void ChangeElement(ref Entry element){
            element.s = "Changed from within method";
        }
