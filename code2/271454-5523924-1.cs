    public class TestClass
    {
        public string Name { get; set; }
        public int Age { get; set; }
    
        public TestClass() { }
    
        public TestClass(string name)
        {
            using (SqlConnection cn = new SqlConnection(myConnectionString))
            using (SqlCommand cmd = cn.CreateCommand())
            {
                 cmd.CommandText= "SELECT Name, Age FROM Person WHERE Name = @Name";
                 cn.Open();
    
                 cmd.Parameters.AddWithValue("@Name", name);
    
                 using (SqlDataReader dr = cmd.ExecuteReader())
                 {
                     if (dr.Read())
                     {
                         Name = name;
                         Age = int.Parse(dr["Age"]);
                     }
                 }
            }
        }
    }
