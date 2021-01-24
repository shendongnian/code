        public class Device : ISetUp
        {
            // Generates a warning here: 'Type parameter DeviceParameter hides class DeviceParameter'
           
            public void SetUp<T>(T parameter)
            {
                DeviceParameter dd = parameter as DeviceParameter;
                Console.WriteLine(dd.Param);
                
            }
        }
