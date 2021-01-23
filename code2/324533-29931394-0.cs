        public void EnsureNoServicePointCertificate(Uri uri)
        {
            // find the service point for the Uri
            ServicePoint sp = ServicePointManager.FindServicePoint(uri);
            // Check if there is a service point and there is a certificate
            if (sp != null && sp.Certificate != null)
            {
                try
                {
                    // ServicePointManager has a hashtable (private static Hashtable s_ServicePointTable) of all service points
                    Type servicePointType = sp.GetType();
                    // ServicePoint.LookupString is the key for the hashtable
                    PropertyInfo lookupStringProperty = servicePointType.GetProperty("LookupString", BindingFlags.Instance | BindingFlags.NonPublic);
                    string lookupString = (string)lookupStringProperty.GetValue(sp, null);
                    // Get the hashtable from ServicePointManager
                    Hashtable s_ServicePointTable = (Hashtable)typeof(ServicePointManager).InvokeMember("s_ServicePointTable",
                        BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField, null, null, null);
                    // ServicePointManager locks the hashtable and calls 
                    // s_ServicePointTable.Remove(servicePoint.LookupString);
                    lock (s_ServicePointTable)
                    {
                        s_ServicePointTable.Remove(lookupString);
                    }
                    // At this point, ServicePointManager calls
                    // servicePoint.ReleaseAllConnectionGroups();
                    MethodInfo release = servicePointType.GetMethod("ReleaseAllConnectionGroups", BindingFlags.Instance | BindingFlags.NonPublic);
                    release.Invoke(sp, null);
                }
                catch { }
            }
        }
