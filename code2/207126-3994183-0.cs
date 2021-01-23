    public partial class Form1 : Form
    {
        public event EventHandler MyTextChanged;
        [Bindable(true)]
        public string MyText
        {
            get { return textBox1.Text; }
            set 
            {
                if (textBox1.Text != value)
                {
                    textBox1.Text = value;
                    OnMyTextChanged();
                }
            }
        }
        MyClass myClass { get; set; }
        public Form1()
        {
            InitializeComponent();
            myClass = new MyClass();
            Binding binding = new Binding("MyText", myClass, "Dic");
            binding.DataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged;
            binding.Parse += new ConvertEventHandler(binding_Parse);
            binding.Format += new ConvertEventHandler(binding_Format);
            DataBindings.Add(binding);
            myClass.AddStuff("uno", "UNO");
        }
        void OnMyTextChanged()
        {
            if (MyTextChanged != null) MyTextChanged(this, EventArgs.Empty);
        }
        void binding_Format(object sender, ConvertEventArgs e)
        {
            if (e.Value is Dictionary<string, string>)
            {
                Dictionary<string, string> source = (Dictionary<string, string>)e.Value;
                e.Value = source.Count.ToString();
            }
        }
        void binding_Parse(object sender, ConvertEventArgs e)
        {
            MessageBox.Show(e.DesiredType.ToString());
        }
        private void changemyClassButton_Click(object sender, EventArgs e)
        {
            myClass.AddStuff(myClass.Dic.Count.ToString(), "'" + myClass.Dic.Count.ToString() + "'");
        }
        private void changeMyTextButton_Click(object sender, EventArgs e)
        {
            MyText = "1234";
        }
    }
    public class MyClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public Dictionary<string, string> Dic { get; set; }
        public MyClass()
        {
            Dic = new Dictionary<string, string>();
        }
        public void AddStuff(string key, string value)
        {
            Dic.Add(key, value);
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Dic"));
        }
    }
