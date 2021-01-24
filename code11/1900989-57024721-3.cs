    public enum PowerUpStatus { Unobtained, Inactive, Active }
    public class Character
    {
        // Create property for powerup status and set the default value to unobtained
        public PowerUpStatus PowerUpStatus { get; set; } = PowerUpStatus.Unobtained;
        // rest of Character implementation omitted
    }
