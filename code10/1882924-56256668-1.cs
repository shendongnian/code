    public class StudentList : Collection<Student>
    {
       public Student this[int ctr]
       {
          get{return this.Items[ctr]; }
          set{ this.Items[ctr] = value; }
       }
        new public Student Add(Student newStudent)
        {
            this.Items.Add(newStudent);
            return (Student)this.Items[this.Items.Count-1];
        }
    }
