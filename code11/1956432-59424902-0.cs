[HttpGet("cars", Name = "GetCars")]
[ProducesResponseType(typeof(IEnumerable<Car>), 200)]
public async Task<IActionResult> GetCars()
{
    var cars = _repo.GetCars().Where(c => c.ShouldSerializeCar );
    retur Ok(cars);
}
