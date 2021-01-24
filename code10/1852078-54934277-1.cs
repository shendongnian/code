    public class FrenchDictionairyModel: 
        IDictionairyModel<FrenchWordModel, EnglishWordModel>
    {
        public int Id { get; set; }
        public FrenchWordModel BaseWord { get; set; } = new FrenchWordModel();
        public List<EnglishWordModel> DerivativeWords { get; set; } =  new List<EnglishWordModel>();
    }
