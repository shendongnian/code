csharp
public async Task<ActionResult<IEnumerable<object>>> GetCarData(Guid carID)
{
    var carData = await (from cl in _context.CarList
                            join tl in _context.transmissionList
                                on cl.CId equals tl.CId
                            join to in _context.transmissionOptions
                                on tl.TId equals to.TId
                            where cl.CId == carID
                            select new
                            {
                                CarId = cl.CarId,
                                TransmissionId = tl.TId,
                                OptionId = to.OptionId,
                                GearId = to.GearId
                            })
                            .GroupBy(x => x.CarId)
                            .Select(g => new
                            {
                                CarId = g.First().CarId,
                                TransmissionId = g.First().TransmissionId,
                                TransmissionChoices = g.Select(x => new
                                {
                                    OptionId = x.OptionId,
                                    GearId = x.GearId
                                })
                            })
                            .ToListAsync();
    return carData;
}
Note that this is projecting the results into an anonymous type. Feel free to create a model that matches the schema you need and then use that model in the `Select(...)` projection.
