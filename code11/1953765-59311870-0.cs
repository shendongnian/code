    public class CarPartConverter : ITypeConverter<IEnumerable<Cars>, IEnumerable<CarsDTO>>
    {
        public IEnumerable<CarsDTO> Convert(IEnumerable<Cars> source, IEnumerable<CarsDTO> destination, ResolutionContext context)
        {
            return source
                .GroupBy(c => new {c.CarCode, c.CarId})
                .Select(g => new CarsDTO
                {
                    CarCode = g.Key.CarCode,
                    CarId = g.Key.CarId,
                    CarParts = g.Select(v => new PartsDTO
                    {
                        Id = v.PartId,
                        PartCode = v.PartCode,
                        Enabled = v.Enabled
                    }).ToList()
                });
        }
    }
