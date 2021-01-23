      public static void Main(string[] args) { 
        Console.WriteLine("start"); 
        using (SqlConnection conn = new SqlConnection())
        {
              Console.WriteLine("middle");              
        }
        Console.WriteLine("finish");             
    } 
