    //Common interface
    public interface IDoCalculation
    {
        //Use whatever method signatures you need
        void DoCalculation();
    }
    public class DeviceImplementation1 : IDoCalculation
    {
        #region IDoCalculation Members
        public void DoCalculation()
        {
            //Device 1 Specific code goes here
        }
        #endregion
    }
    public class DeviceImplementation2 : IDoCalculation
    {
        #region IDoCalculation Members
        public void DoCalculation()
        {
            //Device 2 Specific code goes here
        }
        #endregion
    }
    // A simple factory that does not require a lot of OOP understanding.
    public class DeviceCalculationFactory
    {
        //Return a correct implementor based on the device type passed in
        public IDoCalculation GetCalculationImplementationInstance(string devicetype)
        {
            switch (devicetype)
            {
                case "Device1":
                    return new DeviceImplementation1();
                    
                case "Device2":
                    return new DeviceImplementation2();
                default:
                    //TODO ???
                    return null;
            }
        }
    }
    // A simple client device
    public class Device1
    {
        //To do the calculation, get an implementor for the correct device type from the factory
        public void DoTheCalculationThing()
        {
            DeviceCalculationFactory factory = new DeviceCalculationFactory();
            IDoCalculation calculation = factory.GetCalculationImplementationInstance("Device1");
            calculation.DoCalculation();
        }
    }
