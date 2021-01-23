    //Common interface
    public interface IDoCalculation
    {
        //Use whatever method signatures you need
        int DoCalculation();
    }
    public class DeviceImplementation1 : IDoCalculation
    {
        #region IDoCalculation Members
        public int DoCalculation()
        {
            //Device 1 Specific code goes here
        }
        #endregion
    }
    public class DeviceImplementation2 : IDoCalculation
    {
        #region IDoCalculation Members
        public int DoCalculation()
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
    // A simple client that calls the methods and then send the results
    public class DeviceManager
    {
        //To do the calculation, get an implementor for the correct device type from the factory - Presumably the PC knows the device of interest, example "Device1"
        public void DoTheCalculationThing(string deviceType)
        {
            
            DeviceCalculationFactory factory = new DeviceCalculationFactory();
            IDoCalculation calculation = factory.GetCalculationImplementationInstance(deviceType);
            int result = calculation.DoCalculation();
            // now send the result to the device
        }
    }
