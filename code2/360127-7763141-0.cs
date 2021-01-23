	public class RS485USBDevice
	{
		public int DeviceId { get; set; }
		public string Id_02mm { get; set; } // need more descriptive name
		public string Id_07mm { get; set; } // need more descriptive name
		public string Id_10mm { get; set; } // need more descriptive name
		public DateTime LastRequestTime { get; set; }
		
		public RS485USBDevice(int deviceId)
		{
			this.DeviceId = deviceId;
		}
		
		public void SendRequest()
		{
			// where does CommPort come from? custom class?
			CommPort com = CommPort.Instance;
			string ID = "id0" + this.DeviceId;
			ID = ConvertEscapeSequences(ID);
			com.Send(ID);  // shouldn't this have a return value
			
			// where does stringOut come from? naughty global variable
			this.Id_02mm = stringOut.Trim().Substring(4,5);
			this.Id_07mm = stringOut.Trim().Substring(10,5);
			this.Id_10mm = stringOut.Trim().Substring(16,5);
			this.LastRequestTime = DateTime.Now;
		}
	}
	public class MainClass
	{
		private List<RS485USBDevice> _devices;
		
		public MainClass()
		{
			// initialize setup of all 6 devices
			this._devices = new List<RS485USBDevice>();
			for (int i = 1; i <= 6; i++)
			{
				var device = new RS485USBDevice(i);
				this._devices.Add(device);
			}
		}
		
		// this should be timer tick event on 10 seconds
		private void button6_Click(object sender, EventArgs e)
		{
			// make all devices send
			foreach (var device in this._devices)
				device.SendRequest();
			
			// do something with response data from device obj
		}
	}
