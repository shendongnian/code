public class Apartment : EntityBase
{
    public int Id { get; set; }
    public int BuildingId { get; set; }
    public MultiApartmentBuilding MultiApartmentBuilding { get; set; }
    public Common.Enums.ApartmentState State { get; set; }
    public AccessibilityState Accessibility { get; set; }
    public int Floor { get; set; }
    public bool IsPentHouse { get; set; }
 }
