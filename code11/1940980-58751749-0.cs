    public class CSpaceUsed
    {
        string database_name { get; set; }
        string database_size { get; set; }
        [Column("unallocated space")]
        string unallocated_space { get; set; }
        string reserved { get; set; }
        string data { get; set; }
        string index_size { get; set; }
        string unused { get; set; } 
    };
