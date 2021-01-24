        public class HeadersParameters
        {
            [FromHeader]
            [Required]
            public string Header1 { get; set; }
            [FromHeader]
            public string Header2 { get; set; }
        }
