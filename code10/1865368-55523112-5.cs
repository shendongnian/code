    public static class AddressDtoExtensions
    {
        public static AddressDto PopulatePredefinedValues(
            this AddressDto dto)
        {
            dto.RecipientName = dto.RecipientName ?? "John Doe";
            dto.City = dto.City ?? "City";
            dto.CountryName = dto.CountryName ?? "Country";
            return dto;
        }
    }
