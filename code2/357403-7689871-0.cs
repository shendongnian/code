        public enum SensorTypeA { A = 0 };
        public enum SensorTypeB { B = 1 };
        public enum SensorTypeC { C = 2 };
        private object GetSensorTypeAtLocation()
        {
            return SensorTypeB.B;
        }
  
        private void YourMethod(object sender, EventArgs e)
        {
            object value = GetSensorTypeAtLocation();
            if (value is SensorTypeA)
            {
                Console.WriteLine("A");
            }
            else if (value is SensorTypeB)
            {
                Console.WriteLine("B");
            }
            else if (value is SensorTypeC)
            {
                Console.WriteLine("C");
            }
            else
            {
                Console.WriteLine("Unknown");
            }
        }
