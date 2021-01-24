    public class Student()
    {
    	public string Id {get; set;
    	public string Name {get; set;}
        public string Phone {get; set;}
    	public int Age {get; set; }
    	public string Grade {get; set;}
    
        public Student()
        {
        }
    	
    }
    
    public class Students: IEnumerator,IEnumerable
    {
          private student[] _studentlist;
          int position = -1;
    
          //Create internal array in constructor.
          public Students()
          {
               //read you file into studentlist here
          }
    
          //IEnumerator and IEnumerable require these methods.
          public IEnumerator GetEnumerator()
          {
             return (IEnumerator)this;
          }
    
          //IEnumerator
          public bool MoveNext()
          {
             position++;
             return (position < _studentlist.Length);
          }
    
          //IEnumerable
          public void Reset()
          {position = 0;}
    
          //IEnumerable
          public object Current
          {
             get { return _studentlist[position];}
          }
    
          public void Add(Student Student)
          {
         	  //Implement here
          }
    
          public void Save()
          {
              //persist to a file here
          } 
    
    	public List<Student> Search(string Id)
    	{
    		return _studentlist.Where(s => s.Id = Id);
    		//this could be expanded (e.g. pass in a student object and search on non empty properties)
    	}
    
       }      
