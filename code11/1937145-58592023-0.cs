    public class DigitalControl
    {
        public string Status { get; set; }
        public GpioPin DevicePin  { get; set; }
        public GpioPinValue PinValue { get; set; }
        public int PinNumber { get; set; }
    }
