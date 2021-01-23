    namespace Example
    {
        public class ConfigFile
        {
            public ConfigFile()
            {
                Sensors = new List<ISensorInfo<Int32>>();
            }
            public List<ISensorInfo<Int32>> Sensors { get; set; }
         }
       }
    }
    **using Example.Sensors.Type1; // Added this to not throw the exception**
    using System;
    namespace Example.Sensors
    {
        public interface ISensorInfo<T>
        {
            String SensorName { get; }
        }
    }
    using Example.Sensors;
    namespace Example.Sensors.Type1
    {
        public class Type1SensorInfo<T> : ISensorInfo<T>
        {
            public Type1SensorInfo() 
        }
    }
