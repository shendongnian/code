    public interface Indicator<T>
    {
         DateTime Timestamp { get; }
         T Value { get; }
    }
    public partial class TemperatureIndicator : Indicator<double>
    {
         public double Value { get { return this.Temperature; } }
    }
