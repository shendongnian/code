    public class MyForm : Form
    {
        private LinkedList<string> _list = new LinkedList<string>();
        public void Button1_Click(object sender, EventArgs e)
        {
            var secondForm = new MySecondForm();
            secondForm.SetList(_list);
            secondForm.ShowDialog();
            MessageBox.Show(_list.First.Value);
        }
    }
    public class MySecondForm : Form
    {
        private LinkedList<string> _list;
        public void Window_Loaded(object sender, EventArgs e)
        {
            this._list.AddFirst("This will work");
        }
        public void SetList(LinkedList<string> list)
        {
            _list = list;
        }
    }
