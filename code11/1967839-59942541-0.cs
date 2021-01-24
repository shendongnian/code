    public class InventoryItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string PartNumber { get; set; }
        public double Length { get; set; }
        public double GetLengthInInches => Math.Round(Length / 25.4, 0);
    }
