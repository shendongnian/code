        public interface IMeasurementUnitType
        {
            int ID { get; }
            string Description { get; }
            // Just added to simulate a action needed in the system
            string GetPrintMessage(int size);
        }
