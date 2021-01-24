    public enum PowerUpStatus { Unobtained, Inactive, Active }
    public class Character
    {
        public PowerUpStatus PowerUpStatus { get; set; } = PowerUpStatus.Unobtained;
        // rest of Character implementation omitted
    }
