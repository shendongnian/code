    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Assuming WordTypeId eqauls 1 for Nouns, 2 for Verbs, 3 for Adjectives
        modelBuilder.Entity<Noun>().Map<Word>(c => c.Requires("WordTypeId").HasValue(1));
        modelBuilder.Entity<Verb>().Map<Word>(c => c.Requires("WordTypeId").HasValue(2));
        modelBuilder.Entity<Adjective>().Map<Word>(c => c.Requires("WordTypeId").HasValue(3));
    }
