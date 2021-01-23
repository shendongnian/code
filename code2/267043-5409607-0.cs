    interface IDonutRepository
    {
        IEnumerable<Donut> Donuts { get; }
        .. or ..
        IQueryable<Donut> Donuts { get; }
    }
