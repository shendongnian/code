cs
[HttpPost]
[Authorize(Policy = Policies.Admin)]
public async Task<IActionResult> CreateVehicle([FromBody]SaveVehicleResource vehicleResource)
{
        var userId =  User.FindFirstValue(ClaimTypes.NameIdentifier);
}
