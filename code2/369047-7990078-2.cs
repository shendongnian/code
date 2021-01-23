    namespace PhoneUtilities.Utilities
    {
        public class AccelerometerMath
        {
            public static double RadianToDegree(double radians)
            {
    
                return radians * (180 / Math.PI);
            }
    
            public static double Pitch(AccelerometerReading e)
            {
                return RadianToDegree((Math.Atan(e.Acceleration.X / Math.Sqrt(Math.Pow(e.Acceleration.Y, 2) + Math.Pow(e.Acceleration.Z, 2)))));
            }
    
            public static double Roll(AccelerometerReading e)
            {
                return RadianToDegree((Math.Atan(e.Acceleration.Y / Math.Sqrt(Math.Pow(e.Acceleration.X, 2) + Math.Pow(e.Acceleration.Z, 2)))));
            }
    
            public static double Yaw(AccelerometerReading e)
            {
                return RadianToDegree((Math.Atan(Math.Sqrt(Math.Pow(e.Acceleration.X, 2) + Math.Pow(e.Acceleration.Y, 2)) / e.Acceleration.Z)));
            }
        }
    }
