    public class State : BaseModel
    {
        [System.ComponentModel.DataAnnotations.Key]
        [Dapper.Contrib.Extensions.Key]
        public string state_code { get; set; }
        public string state_name { get; set; }
        public int language_code { get; set; }
        public bool is_active { get; set; }
    }
