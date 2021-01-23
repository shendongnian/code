    using System.Linq;
    .
    .
    .
    public IEnumerable<Enum> GetValues(Enum value)
    {
        return Enum.GetValues(value.GetType()).OfType<Enum>();
    }
