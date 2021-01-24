    JsonConvert.DeserializeObject<List<CsvItem>>(myJSON);
    public class CsvItem
    {
        public string Email { get; set; }
        public string DisplayName { get; set; }
        public string Dpt { get; set; }
    }
