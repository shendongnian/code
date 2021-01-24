c#
    public interface ITypedPosition<T> where T: Position
    {
        IEnumerable<T> Positions { get; }
    }
    public abstract class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int AreaId { get; set; }
        public Area Area { get; set; }
        public byte[] ConcurrencyToken { get; set; }
        public ICollection<Position> Positions { get; set; }
    }
    public class Bay : Location, ITypedPosition<BayRow>
    {
        IEnumerable<BayRow> ITypedPosition<BayRow>.Positions => base.Positions.OfType<BayRow>();
    }
    public class StandardLocation : Location, ITypedPosition<Position>
    {
        IEnumerable<Position> ITypedPosition<Position>.Positions => base.Positions.OfType<Position>();
    }
