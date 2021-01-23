    public class AddressConverter : TypeConverter<AddressViewModel, Address>
    {
        protected override Address ConvertCore(AddressViewModel source)
        {
            return new Address
            {
                Line1 = source.Line1 + " foo",
                City = source.City + " foo",
                State = source.State + " foo"
            };
        }
    }
