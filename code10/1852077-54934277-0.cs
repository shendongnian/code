    public interface IDictionairyModel<T,U> 
        where T : IWordModel, U : IWordModel
    {
        int Id { get; set; }
        T BaseWord { get; set; }
        List<U> DerivativeWords { get; set; }
    }
