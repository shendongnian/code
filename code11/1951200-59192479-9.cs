    public partial class Model
    {
        public int Id { get; set; }
        public byte[] Encrypted { get; set; } // apparently encrypted data is stored in `VARBINARY`, which translates to `byte[]`, so I had to tweak it here
        [NotMapped] // this is still required as EF will not know where to get the data unless we tell it (see down below)
        public string Decrypted { get; set; } // the whole goal of this exercise here
        public Table2 Table2 { get; set; }
    }
