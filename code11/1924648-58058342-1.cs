        public class Number
        {
            public string number { get; set; }
            public double value { get; set; }
            public Number(string number, double value)
            {
                this.number = number;
                this.value = value;
            }
        }
    and inject the values to class by creating an object of list of number
        static void Main(String[] args)
        {
            List<Number> numbers = new List<Number>();
            numbers.Add(new Number("One", 1));
            numbers.Add(new Number("Two", 2));
            numbers.Add(new Number("Three", 3));
        }
