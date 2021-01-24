    public class DoubleGauge : Gauge<double>
    {
        public DoubleGauge() : base((x, y) => x - y)
        {
        }
    }
