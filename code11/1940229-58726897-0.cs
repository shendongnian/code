    public class ReportVersandLogDto
    {
        [JsonPropertyName("anzahlArtikel")]
        public long AnzahlArtikel { get; set; }
    
        [JsonPropertyName("betreff")]
        public string? Betreff { get; set; }
    
        [JsonPropertyName("hasBeenRead")]
        public bool HasBeenRead { get; set; }
    
        [JsonPropertyName("reportId")]
        public long ReportId { get; set; }
    
        [JsonPropertyName("reportVersandLogId")]
        public long ReportVersandLogId { get; set; }
    
        [JsonPropertyName("versendetAm")]
        public string? VersendetAm { get; set; }
    
        [JsonPropertyName("link")]
        public string? Link { get; set; }
    }
