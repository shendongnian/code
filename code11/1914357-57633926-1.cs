    public class DatabaseAddressMapper : IMapper<Address, DB1_ADDRESS>
    {
        public DB1_ADDRESS MapModelToEntity(Address source) { ... }
        Address MapEntityToModel()
    }
    public class WSAddressMapper : IMapper<Address, WS_ADDRESS>
    {
        public WS_ADDRESS MapModelToEntity(Address source) { ... }
        Address MapEntityToModel()
    }
