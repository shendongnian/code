    public class MyClass
    {
        public int MyClassID { get; set; } 
    
        // Empty list by default
        private List<Note> m_Notes = new List<Note>();
    
        public List<Note> Notes
        {
            get
            {
                return m_Notes; 
            }
            set // If you really want "set" in the context
            {
                // Assign empty list if value is null
                m_Notes = value ?? new List<Note>();
            }   
        }
    }
