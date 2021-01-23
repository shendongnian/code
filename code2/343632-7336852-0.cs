    public class MyForm : Form
    {
        public LinkedList<string> _list = new LinkedList<string>();
    }
    public class MySecondForm : Form
    {
        public void Window_Loaded(object sender, EventArgs e)
        {
            MyForm._list.AddFirst("This doesn't work");
            //WRONG! list is an instance variable we are trying to access statically.
        }
    }
