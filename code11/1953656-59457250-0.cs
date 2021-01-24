public Form1()
        {
            InitializeComponent();
            MMDeviceEnumerator enumerator = new MMDeviceEnumerator();
            var devices = enumerator.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active);
            //comboBox1.Items.AddRange(devices.ToArray()); //required
            foreach (var dev in devices)
            {
                
                comboBox1.Items.Add(dev);
            }
            comboBox1.Text = "Speaker/Headphone (Realtek High Definition Audio)";  //reauired
      
        }
