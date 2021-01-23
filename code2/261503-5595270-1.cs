    public class ...DTO
    {
            public int Id { get; set; }
            public string Name { get; set; }
            public string C1D
            {
                get
                {
                    if (!C1SD.HasValue) return string.Empty;
                    return (DateTime.ParseExact(C1SD, "yyyy/mm/dd", null) < DateTime.Today.AddDays(-183)) ? "Green" : "";
                }
            }
    }
