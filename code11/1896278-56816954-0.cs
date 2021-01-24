asp
Seed seed = new Seed();
var groups = seed.SeedGroupsVehicles();
var filteredGroups = groups
	.Select(g => new Group {
		Id = g.Id,
		Name = g.Name,
		// Here is where you filter Vehicles
		Vehicles = g.Vehicles.Where(v => v.PlateNo.Contains("A0-")),
	});
