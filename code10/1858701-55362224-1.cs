    class Histogram
    {
        [LoadColumn(0)]
        public float Target;
        [LoadColumn(1, 64), ColumnName("Sensor1"), VectorType(64)]
        public float[] Sensor1;
        [LoadColumn(65, 129), ColumnName("Sensor2"), VectorType(64)]
        public float[] Sensor2;
    
        [LoadColumn(130, 193), ColumnName("Sensor3"), VectorType(64)]
        public float[] Sensor3;
        [LoadColumn(194, 257), ColumnName("Sensor4"), VectorType(64)]
        public float[] Sensor4;
        [LoadColumn(258, 321), ColumnName("Sensor5"), VectorType(64)]
        public float[] Sensor5;
        [LoadColumn(322, 385), ColumnName("Sensor6"), VectorType(64)]
        public float[] Sensor6;
    }
