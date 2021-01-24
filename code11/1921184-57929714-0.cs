    public class ControlP
    {
        public string Com {get;set;}
        public int Pri { get; set; }
        public string Not {get;set;}
    }
    ......
    List<ControlP> results = new List<ControlP>();
    string pquery = "SELECT * FROM controlp";
    // Don't forget to enclose the connection in a using statement. It is a 
    // disposable object and should be correctly destroyed when you finish to use it
    using(NpgsqlConnection conn = new NpgsqlConnection(Utils.ConnectionString))
    using(NpgsqlCommand pcmd = new NpgsqlCommand(pquery, conn))
    {
        conn.Open();
        using(NpgsqlDataReader reader = pcmd.ExecuteReader())
        {
            while(reader.Read())
            {
                 ControlP p = new ControlP();
                 p.Com = reader["com"].ToString();
                 p.Pri = Convert.ToInt32(reader["pri"]);
                 p.Not = reader["not"].ToString();
                 results.Add(p);
            }
            pDGV.DataSource = p;
            comComboBox.DataSource = p;
            comComboBox.DisplayMember = "Com";
            comComboBox.ValueMember = "Pri";
        }
    }
