    public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                List<Student> list = new List<Student>();
                list.Add(new Student { Age=12,Name="Test1",Title="Hello" });
                list.Add(new Student { Age = 13, Name = "Test2", Title = "Hi" });
                list.Add(new Student { Age = 15, Name = "Test5", Title = "Greeting" });
                dataGridView1.DataSource = list;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                List<Student> list = (List<Student>)dataGridView1.DataSource;
                list.Add(new Student { Age = 16, Name = "Test6", Title = "Hello1" });
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = list;
            }
        }
    
        public class Student
        {
            public int Age { get; set; }
            public string Name { get; set; }
    
            public string Title { get; set; }
    
    
        }
