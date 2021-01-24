    interface IDAO
    {
     // method signatures and properties here for the DAO
    }
    class DAO : IDAO
    { 
      // specific code about the DAO. such as connection to DBs, methods, props, etc...
    } 
    class StudentController:ControllerBase
    {
        private readonly IDAO _dao
        public StudentController(IDAO dao)
        {
          _dao = dao;
        }
    }
