    public partial class Listbox_Databinding : Form
    {
        BindingList<Person> People = new System.ComponentModel.BindingList<Person>();
        public Listbox_Databinding()
        {
            InitializeComponent();
            People.Add(new Person("John", "Smith"));
            People.Add(new Person("John", "Jacob"));
            lstSelectPerson.DataSource = People;
        }
        private void lstSelectPerson_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtLast.Text = ((Person)lstSelectPerson.SelectedItem).Last;
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ((Person)lstSelectPerson.SelectedItem).Last = txtLast.Text;
        }
    }
    public class Person : INotifyPropertyChanged
    {
        public Person(string first, string last)
        {
            First = first;
            Last = last;
        }
        public override string ToString()
        {
            return Last + ", " + First;
        }
        string p_first;
        string p_last;
        public string First
        {
            get { return p_first; }
            set
            {
                p_first = value;
                OnDisplayPropertyChanged();
            }
        }
        public string Last
        {
            get { return p_last; }
            set
            {
                p_last = value;
                OnDisplayPropertyChanged();
            }
        }
        void OnDisplayPropertyChanged()
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs("DisplayName"));
        }
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
