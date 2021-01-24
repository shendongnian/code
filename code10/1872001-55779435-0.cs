	public partial class Form1 : Form
	{
		private Students _students = new Students();
		public Form1()
		{
			InitializeComponent();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			_students.Sort(Students.SortByName);
			this.Vivod(listBox1);
		}
		private void button1_Click(object sender, EventArgs e)
		{
			_students.Add(new Student(textBox1.Text, int.Parse(textBox2.Text), int.Parse(textBox3.Text)));
		}
		private void Vivod(ListBox listBox)
		{
			listBox.Items.Clear();
			listBox.Items.AddRange(_students.ToStrings());
		}
	}
	
	public class Students
	{
		private int _items = 0;
		private const int __n = 10;
		private Student[] students = new Student[__n];
		public Student this[int num]
		{
			get => students[num - 1];
			set { (students[num - 1]) = value; }
		}
		public string[] ToStrings() => Enumerable.Range(0, _items).Select(i => students[i].ToString() + " ").ToArray();
		public void LoadStudents()
		{
			this.Add(new Student("А", 13, 68));
			this.Add(new Student("Б", 18, 67));
			this.Add(new Student("В", 5, 75));
		}
		public void Add(Student load)
		{
			if (_items < __n)
			{
				students[_items++] = load;
			}
		}
		public void Sort(IComparer<Student> comparer)
		{
			Array.Sort(students, comparer);
		}
		private class SortByNameComparer : IComparer<Student>
		{
			public int Compare(Student o1, Student o2) => string.Compare(o1.Name, o2.Name);
		}
		private class SortByDaysComparer : IComparer<Student>
		{
			public int Compare(Student o1, Student o2) => o1.Days > o2.Days ? 1 : (o1.Days < o2.Days ? -1 : 0);
		}
		private class SortByHemoglobinComparer : IComparer<Student>
		{
			public int Compare(Student o1, Student o2) => o1.Hemoglobin > o2.Hemoglobin ? 1 : (o1.Hemoglobin < o2.Hemoglobin ? -1 : 0);
		}
		public static IComparer<Student> SortByName => new SortByNameComparer();
		public static IComparer<Student> SortByDays => new SortByDaysComparer();
		public static IComparer<Student> SortByHemoglobin => new SortByHemoglobinComparer();	
	}
	
	public class Student
	{
		public string Name { get; set; } = "";
		public int Days { get; set; } = 0;
		public int Hemoglobin { get; set; } = 0;
		public Student() { }
		public Student(string name, int days, int hemoglobin)
		{
			this.Name = name;
			this.Days = days;
			this.Hemoglobin = hemoglobin;
		}
		public Student(Student s) : this(s.Name, s.Days, s.Hemoglobin) { }
		public override string ToString() => $"{this.Name} {this.Days} {this.Hemoglobin}";
	}
