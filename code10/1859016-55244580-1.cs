    public class GoogleTracking : IAnalyticsSession
        {
            static string _GoogleAnayticsPropertyID = string.Empty;
            static AnalyticsSession _Session = new AnalyticsSession();
            static Dictionary<int, string> _CustomDimensions = new Dictionary<int, string>();
            static int iVal = 0;
    
            public GoogleTracking(string googleID)
            {
                _GoogleAnayticsPropertyID = googleID;
            }
            public string GenerateCacheBuster()
            {
                return _Session.GenerateCacheBuster();
            }
    
            public string GenerateSessionId()
            {
                return _Session.GenerateSessionId();
            }
    
            public void UserDefined(string strUserVal)
            {
                _CustomDimensions.Add(iVal++, strUserVal);
            }
    
    
            public static void TrackFeature()
            {
                StackTrace stackTrace = new StackTrace();
                MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
                TrackFeature(methodBase.Name);
            }
    
            public static async void TrackFeature(string FeatureCustom)
            {
                if (!string.IsNullOrEmpty(_GoogleAnayticsPropertyID))
                {
                    SimpleTrackerEnvironment trackerEnvironment = new SimpleTrackerEnvironment(Environment.OSVersion.Platform.ToString(),
                                                                                Environment.OSVersion.Version.ToString(),
                                                                                Environment.OSVersion.VersionString);
    
                    // Overwrite platform details
                    KeyValuePair<string, string> kvpOSSpecs = GetOperatingSystemProductName();
                    trackerEnvironment.OsPlatform = kvpOSSpecs.Key;
                    trackerEnvironment.OsVersion = kvpOSSpecs.Value;
    
                    SimpleTracker tracker = new SimpleTracker(_GoogleAnayticsPropertyID, _Session, trackerEnvironment);
    
                    await tracker.TrackPageViewAsync(System.AppDomain.CurrentDomain.FriendlyName, FeatureCustom, _CustomDimensions);
                }
            }
    
    
    
            static KeyValuePair<string, string> GetOperatingSystemProductName()
            {
                KeyValuePair<string, string> OperatingSystemSpec = new KeyValuePair<string, string>();
                ManagementObjectSearcher wmiOsInfo = new ManagementObjectSearcher("SELECT Caption, Version FROM Win32_OperatingSystem");
                try
                {
    
                    foreach (var os in wmiOsInfo.Get())
                    {
                        var version = os["Version"].ToString();
                        var productName = os["Caption"].ToString();
                        OperatingSystemSpec = new KeyValuePair<string, string>(productName, version);
                    }
                }
                catch (Exception ex)
                { 
                      Messagebox.Show(ex);
                }
    
                return OperatingSystemSpec;
            }
        }
