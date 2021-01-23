     public partial class gridViewLongText : System.Web.UI.Page
     {
         protected void Page_Load(object sender, EventArgs e)
         {
             #region init and bind data
             List<Person> list = new List<Person>();
             list.Add(new Person(1, "Sam"));
             list.Add(new Person(2, "Max"));
             list.Add(new Person(3, "Dave"));
             list.Add(new Person(4, "TabularasaVeryLongName"));
             gvPersons.DataSource = list;
             gvPersons.DataBind();
             #endregion
         }
     }
     public class Person
     {
         public int ID { get; set; }
         public string Name { get; set; }
         public Person(int _ID, string _Name)
         {
             ID = _ID;
             Name = _Name;
         }
     }
