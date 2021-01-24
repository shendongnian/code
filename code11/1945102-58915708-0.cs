    class Device : ISetUp<DeviceParameter>
    {
        public void SetUp(DeviceParameter parameter)
        {
            Console.WriteLine(parameter.Param);
        }
    }
