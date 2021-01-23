    class Tunnel
    {
        [Range(0, double.MaxValue, ErrorMessage = "Length must be positive value.")]
        public double Length { get; set; }
    }
