    public class NextFormResult
    {
        public string Field1 { get; set; }
        public string Field2 { get; set; }
    }
    
    string sql = "SELECT * FROM nextcare_form";
    
    using (var connection = new SqlConnection("YOUR CONNECTION"))
    {            
        var nextFormResult = connection.Query<NextFormResult>(sql).ToList();
    
    	// more code
    }
