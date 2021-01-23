        public class PointMeasurementUnitType : IMeasurementUnitType
        {
            public int ID => 3;
            public string Description => "Point";
            public string GetPrintMessage(int size)
            {
                return $"This is a {Description} Measurement that is equal to {size} points of total screen size";
            }
        }
