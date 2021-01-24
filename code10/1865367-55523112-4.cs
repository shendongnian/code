    public static class AddressDtoFactory
    {
        public static AddressDto CreateWithPredefinedValues()
        {
            return new AddressDto
            {
                RecipientName = "John Doe",
                City = "City",
                CountryName = "Country"
            };
        }
    }
