    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Threading.Tasks;
    
    namespace APD_Remastered_Ideas.Models
    {
        public class TestModel
        {
            [Key]
            public int Id { get; set; }
            public string address { get; set; }
        }
    }
