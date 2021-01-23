    public partial class Form1 : Form
    {
        public Number SomeNumber { get; set; }
        public Form1()
        {
            InitializeComponent();
            SomeNumber = new One();
            SomeNumber = (Number)Activator.CreateInstance(SomeNumber.GetType(), new[] {1});
        }
    }
    public class Number
    {
        
    }
    public class One : Number
    {
        public One()
        {
            
        }
        public One(Object a)
        {
            
        }
    }
