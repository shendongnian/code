    public class StudentList : ObservableCollection<Student>
    {
        public int CountOfHandlers { get; private set; }
    
        public override event NotifyCollectionChangedEventHandler CollectionChanged
        {
            add {if (value != null) CountOfHandlers += value.GetInvocationList().Length;}
            remove { if (value != null)CountOfHandlers -= value.GetInvocationList().Length; }
        }
    }
        
    public class School
    {
        public School()
        {
            studentList = new StudentList();
            //only when studentList.CollectionChanged is empty i want 
            // to execute the below statement
            if (studentList.CountOfHandlers == 0)
            {
                studentList.CollectionChanged += studentList_CollectionChanged;
            }
        }
    
        public StudentList studentList { get; set; }
    
        private void studentList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e){}
    }
    
    public class Student { }
