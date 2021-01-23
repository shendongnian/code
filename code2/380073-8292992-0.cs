    public class IODeviceWrapper : INotifyPropertyChanged
    {
        public IODeviceWrapper(IODevice ioDevice)
        {
            _ioDevice = ioDevice;
            _ioDevice.ValueChanged += ValueChanged;
        }
        private IODevice _ioDevice;
        public event PropertyChangedEventHandler PropertyChanged;
        private void ValueChanged()
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Value"));
            }
        }
        public int Value
        {
            get { return _ioDevice.Value; }
            set
            {
                //Do ansynchronous IO
                Task task = new Task(() => _ioDevice.DoIO(value));
                task.Start();
            }
        }
    }
