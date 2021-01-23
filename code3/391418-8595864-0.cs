    public class Form1
    {
        public DataGridView DGV { get; set; }
        private void DoSomething()
        {
            var anotherForm = new Form2();
            anotherForm.DoSomethingElse(this);
        }
    }
    public class Form2
    {
        public void DoSomethingElse(Form1 firstForm)
        {
            var data = firstForm.DGV.DataSource;
        }
    }
