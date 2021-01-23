    public interface IPersona
    {
        string nome { get; set; }
        string cognome { get; set; }
        Func<Owned<ISomeInterface>> somemethod { get; set; }
        
    }
