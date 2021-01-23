    public class MyParser
    {
        // load xml string or xml file in constructor
        public MyParser(string xmlSource) { .. }
        
        public EmployeeModel GetEmployeeModel()
        {
             var result = new EmployeeModel();
             // use what ever you want to select nodes from your xml
             // and set data of result
             
             return result;
        }
    }
