    public class ModelOutput
    {
        [ColumnName("Score")]
        public float bmi;
    }
    
    public class ModelInput
    {
        [LoadColumn(0)]
        public float NoPreg;
        [LoadColumn(2)]
        public float blPressure;
        [LoadColumn(3)]
        public float BiSkinthck;
        [LoadColumn(5)]
        public float bmi;
        [LoadColumn(7)]
        public float age;
    }
