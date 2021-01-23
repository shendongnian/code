    public class PersonMap:ClassMap<Person>
    {
        public PersonMap()
        {
            Table("Person");
            Id(x=>Id).Column("PersonID");
            References(x=>x.Student).KeyColumn("StudentID")
                Nullable().Cascade.All();
            References(x=>x.Teacher).KeyColumn("TeacherID")
                Nullable.Cascade.All();
        }
    }
    
    
    public class TeacherMap:ClassMap<Teacher>
    {
        public TeacherMap()
        {
            Table("Teacher");
            Id(x=>Id).Column("TeacherID");
            References(x=>x.Person).KeyColumn("PersonID")
                .Not.Nullable().Cascade.None();        
        }
    }
    public class StudentMap:ClassMap<Student>
    {
        public StudentMap()
        {
            Table("Student");
            Id(x=>Id).Column("StudentID");
            References(x=>x.Person).KeyColumn("PersonID")
                .Not.Nullable().Cascade.None();        
        }
    }
