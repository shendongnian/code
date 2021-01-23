    public interface IMyBindingObject
    {
        string A { get; set; }
        string C { get; set; }
    }
    public class MyObject : IMyBindingObject
    {
        public MyObject(string a, string b, string c)
        {
            A = a;
            B = b;
            C = c;
        }
        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
    }
    private void Form1_Load(object sender, EventArgs e)
    {
        List<IMyBindingObject> obj = new List<IMyBindingObject>();
        obj.Add(new MyObject("Test A", "Test B", "Test C"));
        obj.Add(new MyObject("T A", "T B", "T C"));
        dataGridView1.AutoGenerateColumns = true;
        dataGridView1.DataSource = obj;
    }
