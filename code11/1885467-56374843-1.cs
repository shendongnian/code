    namespace MyNamespace
    {
        using System;
        using System.Collections.Generic;
        
        using System.ComponentModel.DataAnnotations;
        
        public partial class MyModel
        {
            [Required]
            public int Id { get; set; }
            [Required]
            [MaxLength(20)]
            public string MyField { get; set; }
        }
    }
