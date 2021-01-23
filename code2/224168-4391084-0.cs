        public partial class Form1 : Form
        {
            Person _person = new Person();
    
            public Form1()
            {
                InitializeComponent();
    
                textBox1.DataBindings.Add(new Binding("Text", _person, "FirstName"));
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                _person.FirstName = textBox2.Text;
            }
        }
    
        public class Person : INotifyPropertyChanged
        {
            private String _firstName = "Aaron";
            public String FirstName
            {
                get
                {
                    return _firstName;
                }
                set 
                {
                    _firstName = value;
                    PropertyChangedEventHandler handler = PropertyChanged;
                    if(handler != null)
                        handler(this, new PropertyChangedEventArgs("FirstName"));
                }
            }
    
            #region INotifyPropertyChanged Members
    
            public event PropertyChangedEventHandler PropertyChanged;
    
            #endregion
        }
    
      [1]: http://msdn.microsoft.com/en-us/library/ef2xyb33.aspx
