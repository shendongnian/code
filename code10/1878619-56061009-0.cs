    public class StudentViewModel
    {
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();
        public void LoadStudents(string query)
        {
            Students.Clear();
            SP.ClientContext ctx = clientContext._clientContext;
            SP.CamlQuery qry = new SP.CamlQuery();
            qry.ViewXml = query;
            SP.ListItemCollection splStudents =  ctx.Web.Lists.GetByTitle("Students").GetItems(qry);
            ctx.Load(splStudents);
            ctx.ExecuteQuery();
            foreach (SP.ListItem s in splStudents)
            {
                Students.Add(new Student { Title = (string)s["Title"], FullName = (string)s["FullName"] });
            }
        }
    }
