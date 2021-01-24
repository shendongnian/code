    public class Win32_EncryptableVolume : WMIInstance
    {
      public string DeviceID {get; set;}
      public string PersistentVolumeID {get; set;}
      public string DriveLetter {get; set;}
      public int ProtectionStatus {get; set;}
      [WMIIgnore]
      public int Version {get; set;}
      public int GetVersion()
	  {
	     return WMIMethod.ExecuteMethod<int>(this)
	  }
    }
