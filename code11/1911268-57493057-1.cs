csharp
[HttpGet("{dcID}")]
public async Task<ActionResult<esfDailyFuel>> GetesfDailyFuel(int dcID)
{
    var doc = await _context.esfDailyFuel
        .Include(d => d.Items)
            .ThenInclude(ft => ft.esfFuelTypes)
        .Include(d => d.Items)
            .ThenInclude(eo => eo.mnEnergyObjects)
        .FirstOrDefaultAsync(d => d.dcID == dcID);
    if (doc == null)
    {
        return NotFound();
    }
    return doc;
}
