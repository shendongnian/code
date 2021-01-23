    public class hexGrid : IHexGridnot               
    {
        public List<Hex> _hexs { get; set; }
        public IEnumerable<Hex> hexs
        {
           get { return _hexs as IEnumerable; }
           set { _hexs = new List<Hex>( value ); }
        }
    }
