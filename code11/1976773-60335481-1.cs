    public static class Extensions
    {
        public static PlaceDTO ToDto(this Place place)
        {
            if (place != null)
            {
                return new PlaceDTO
                {
                    Id = place.Id,
                    Name = JsonConvert.DeserializeObject<Localized<string>>(place.Name)
                };
            }
    
            return null;
        }
    }
