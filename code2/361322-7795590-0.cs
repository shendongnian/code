    class DisplayNameStrategy<T> {
        private readonly Func<T, string> nameSelector;
        public void DisplayNameStrategy(Func<T, string> nameSelector) {
            this.nameSelector = nameSelector;
        }
        public void abstract DisplayName(T t);
    }
    class WriteToConsoleDisplayNameStrategy<T> : DisplayNameStrategy<T> {
        public void WriteToConsoleDisplayNameStrategy(Func<T, string> nameSelector)
            : base(nameSelector) { }
        public override void DisplayName(T t) {
            Console.WriteLine(this.nameSelector(t));
    }
    public class Person {
        private readonly DisplayNameStrategy<Person> displayNameStrategy =
            new WriteToConsoleDisplayNameStrategy<Person>(x => x.Name);
       
        public string Name { get; set; }
        public void DisplayName() {
            this.displayNameStrategy(this);
        }
    }
    
