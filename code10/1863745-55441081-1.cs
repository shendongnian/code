    [Display(Name = "Attach photo")]
        [Required(ErrorMessage = "Please upload image")]
        [ImageCheck(ErrorMessage = "Byte array is incorrect image")]
        public byte[] Photo { get; set; }
       }
