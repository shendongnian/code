    public class Widget : BaseUnit
    {
        [InverseProperty("Widget")]
        public virtual List<IndexedWebpageWidget> Webpages { get; set; }
    }
    
    public class Webpage : BaseUnit
    {
        [InverseProperty("Webpage")]
        public virtual List<IndexedWebpageWidget> Widgets { get; set; }
    }
