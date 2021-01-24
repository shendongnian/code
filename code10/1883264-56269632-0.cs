     var json = @"{
                   'UsbDevices': [
                                'SA',
                                'SB',
                                'SC',
                                'SE2',
                                'SF',
                                'M'],
                   'DeviceConnectivityExperationDateTime' : '2020-12-30'
                  }";                
                    var items = JsonConvert.DeserializeObject<Data>(json);           
            }
    public class Data
    {
       public Data()
       {
          this.UsbDevices = new List<string>();
       }
       public List<string> UsbDevices { get; set; }
       public string DeviceConnectivityExperationDateTime { get; set; }
     }
