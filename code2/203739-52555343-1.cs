        public class PixelsMeasurementUnitType : IMeasurementUnitType
        {
            public int ID => 1;
            public string Description => "Pixel";
            public string GetPrintMessage(int size)
            {
                return $"This is a {Description} Measurement that is equal to {size} pixels of the total screen size";
            }
        }
        public class PercentMeasurementUnitType : IMeasurementUnitType
        {
            public int ID => 2;
            public string Description => "Persentage";
            public string GetPrintMessage(int size)
            {
                return $"This is a {Description} Measurement that is equal to {size} persent of total screen size (100)";
            }
        }
