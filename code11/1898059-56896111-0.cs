    public partial class Page30 : ContentPage
	{
		public Page30 (int Id)
		{
			InitializeComponent ();
            this.BindingContext = new Term(Id);
		}
	}
    public class Term
    {
        public List<Class1> classes { get; set; }
        public int TermId { get; set; }
        public string TermName { get; set; }
        public DateTime TermStartDate { get; set; }
        public DateTime TermEndDate { get; set; }
           
        public Term(int TermId)
        {
            this.TermId = TermId;
            this.TermName = String.Concat("TermName", TermId);
            TermStartDate = new DateTime(2017,7,24);
            
            TermEndDate = new DateTime(2019,01,01);
            classes = new List<Class1>()
            {
                new Class1(){ClassName="class a"},
                 new Class1(){ClassName="class b"},
                  new Class1(){ClassName="class c"},
                   new Class1(){ClassName="class d"},
                    new Class1(){ClassName="class e"},
                     new Class1(){ClassName="class f"},
                   new Class1(){ClassName="class g"},
            };          
        }
    }
    public class Class1
    {
        public string ClassName { get; set; }
    }
