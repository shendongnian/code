    List<PartMeasurements> N = new List<PartMeasurements>();
    N.Add(new PartMeasurements(24, new double[,] { {54, -0.146}, {9, 1.2}, {16, 0.097}, {15, 1}, {64, -0.9774} }));
    N.Add(new PartMeasurements(4, new double[,] { {32, 0.76}, {45, 1.472}, {18, 0.005}, {52, 1.1}, {31, -0.1} }));
    N.Add(new PartMeasurements(73, new double[,] { {81, 1.56}, {24, 1.34}, {9, 0.2}, {2, 0.6}, {55, -0.5} }));
    public class PartMeasurements
    {
        public int BoxSerial_No;
        public double[,] partNumber_and_Measurement = new double[5, 1];
        public Numbers(int BoxSerial_No, double[,] partNumber_and_Measurement)
        {
            this.BoxSerial_No = BoxSerial_No;
            this.partNumber_and_Measurement = partNumber_and_Measurement;
        }
    }
