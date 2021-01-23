    public class Car
    {
        public virtual void Drive()
        {
        }
    }
    public class ChevyVolt : Car
    {
        public override void Drive()
        {
            // Initialize the battery and go
        }
    }
    public class CadillacEscalade : Car
    {
        public override void Drive()
        {
            // Check to ensure you have an oil field worth of gas and go
        }
    }
