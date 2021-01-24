    public class Observation
        {
            private float[] m_Features = new Single[10];
    
            [VectorType(10)]
            public float[] Features
            {
                get
                {
                    return m_Features;
                }
            }
    
            public int Target { get; set; }
    
        }
    
        public class ModelOutput
        {
            // ColumnName attribute is used to change the column name from
            // its default value, which is the name of the field.
            [ColumnName("PredictedLabel")]
            public Int32 Prediction { get; set; }
            public float[] Score { get; set; }
        }
