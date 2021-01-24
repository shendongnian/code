    public class Reservation{ 
    public int ReservationId {get;set;} 
    public int RestaurantId {get;set;} 
    [JsonIgnore]
    public Restaurant Restaurant {get;set;} 
