    public partial class Form1 : Form
    {
        public Number SomeNumber { get; set; }
        public Form1()
        {
            InitializeComponent();
            var _output = new Dictionary<int, List<Number>>
                              {
                                  {
                                      1, new List<Number>
                                             {
                                                 new Number {details = new Number.Details{a = true, b = true, c = true}},
                                                 new Number {details = new Number.Details{a = false, b = false, c = false}},
                                                 new Number {details = new Number.Details{a = true, b = true, c = false}},
                                                 new Number {details = new Number.Details{a = false, b = false, c = false}},
                                                 new Number {details = new Number.Details{a = true, b = true, c = true}},
                                             }
                                      }
                              };
            var itemsToSend = (from kvp in _output
                               from num in kvp.Value
                               where num.details.a && num.details.b && num.details.c
                               select num).ToList();
        }
    }
    public class Number
    {
        public Details details { get; set; }
        public class Details
        {
            public bool a;
            public bool b;
            public bool c;
        }
    }
