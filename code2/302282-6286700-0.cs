    public partial class BuildingDomainContext
    {
        public EntitySet<Room> Rooms
        {
            get
            {
                return EntityContainer.GetEntitySet<Room>();
            }
        }
    }
