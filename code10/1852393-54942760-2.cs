    .Select(e => new CarSharingEntry {
        ShareMeeting = e.ShareMeeting,
        SelectedOptions = e.SelectedOptions,
        SharedCar = new SharedCar {
            Vignette = e.SharedCar.Vignette.Select(v => new {
                v.Id,
                v.GUID,
                v.CountryName,
                v.CountryCode
            }),
            VehicleType = e.SharedCar.VehicleType,
            Equipment = e.SharedCar.Equipment,
            // etc, etc...
        },        
    }).ToList()
