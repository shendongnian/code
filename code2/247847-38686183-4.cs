    [Export]
        [PartCreationPolicy(CreationPolicy.Shared)]
        public class StudentViewModel : ViewModelBase
        {        
           
            private readonly IStudentRepository _repository;
    
            [ImportingConstructor]
            public StudentViewModel()
            {
                          
                _repository =new StudentRepository();
    
                Student = new Student();         
                SaveStudentCommand = new RelayCommand(OnStudentSaveExcute, CanSaveStudent);
               
            }
    
           
    
            #region Properties
            private Student _student;
    
            public Student Student
            {
                get { return _student; }
                set { _student = value; OnPropertyChanged(() => Student); }
            }
    
          
            private ObservableCollection<Student> _students = new ObservableCollection<Student>();
    
            public ObservableCollection<Student> Students
            {
                get { return _students; }
                set { _students = value; }
            }
    
           
    
            #endregion
    
            #region Commands
            public ICommand SaveStudentCommand { get; set; }
    
    
            private void OnStudentSaveExcute()
            {
              
                
                _repository.SaveStudent(Student,Gurdian, (student) =>
                {
                    _students.Add(student);
                });
    
            }
           
            #endregion
           
    
            private  void LoadStudents()
            {
                
                _repository.FindAsync<Student>((students) =>
                {
                    foreach(var student in students)
                    _students.Add(student);
                });
            }
         
        }
---------------------------
