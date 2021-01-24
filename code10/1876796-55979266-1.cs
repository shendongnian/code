    public static List<Doctor> MakeDoctorsListFrom(List<ProviderLocation> providerLocations)
        {
            return providerLocations.ConvertAll<Doctor>((input) => new Doctor()
            {
                ProviderId = input.ProviderId,
                FirstName = input.FirstName,
                Locations = new List<DoctorLocation>(){
                    new DoctorLocation(){
                        AddressId = input.AddressId,
                        City = input.City
                    }
                }
            });
        }
