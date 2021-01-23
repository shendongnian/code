    class MyCollection<T> 
    {
        List<T> _table;
        public List<T> Table
        {
            get
            {
                return _table;
            }
        }
        // ... other access/utility functions common for all tables 
        //     (CRUD for example)
    }
    class Employees : MyCollection<Employee>
    {
        // ... yet more methods 
    }
