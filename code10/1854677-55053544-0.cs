    [Serializable]
    public class ArgumentiViewModel
    {
        public string NomeArgomento { get; set; }
        public bool? Archiviato { get; set; }
        public int? NumeroRigaPerArea { get; set; }
        public string TestoPerArgomento { get; set; }
        public string NomeArea { get; set; } // From Area
        public string NomeCognome { get; set; } // From Moderator
    }
