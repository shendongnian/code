    public class Service1 : IService1
    {
      [EnableCors(origins: "*", headers: "*", methods: "*")]
      List<string> GetAllStudents()
      {
        // Details omitted
      }
    }
