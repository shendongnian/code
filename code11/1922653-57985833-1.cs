    [HttpPost]
    public void Post([FromBody] MyValue value)
    {
    }
    public class MyValue {
        public int projectID { get; set; }
        
        //Other property 
    } 
