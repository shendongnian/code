    public class WordMapping : ClassMap<Word>
    {
        public WordMapping()
        {
            Id(x => x.Id);
            Map(x => x.Text);
            HasManyToMany(x => x.Synonyms).ParentKeyColumn("WordId")
                                                  .ChildKeyColumn("SynonymId")
                                                  .Table("Synonyms");
            HasManyToMany(x => x.Antonyms).ParentKeyColumn("WordId")
                                                  .ChildKeyColumn("AntonymId")
                                                  .Table("Antonyms");
        }
    }
