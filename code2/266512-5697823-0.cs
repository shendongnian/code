    using System;
    using System.Threading;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.Office.Interop.Excel;
    
    namespace StackOverflow
    {
        public class Countdown
        {
            public int CurrentValue { get; set; }
        }
    
        [Guid("EBD9B4A9-3E17-45F0-A1C9-E134043923D3")]
        [ProgId("StackOverflow.RtdServer.ProgId")]
        public class RtdServer : IRtdServer
        {
            private readonly Dictionary<int, Countdown> _topics = new Dictionary<int, Countdown>();
            private Timer _timer;
    
            public int ServerStart(IRTDUpdateEvent rtdUpdateEvent)
            {
                _timer = new Timer(delegate { rtdUpdateEvent.UpdateNotify(); }, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
                return 1;
            }
    
            public object ConnectData(int topicId, ref Array strings, ref bool getNewValues)
            {
                var start = Convert.ToInt32(strings.GetValue(0).ToString());
                getNewValues = true;
    
                _topics[topicId] = new Countdown { CurrentValue = start };
    
                return start;
            }
    
            public Array RefreshData(ref int topicCount)
            {
                var data = new object[2, _topics.Count];
                var index = 0;
    
                foreach (var entry in _topics)
                {
                    --entry.Value.CurrentValue;
                    data[0, index] = entry.Key;
                    data[1, index] = entry.Value.CurrentValue;
                    ++index;
                }
    
                topicCount = _topics.Count;
    
                return data;
            }
    
            public void DisconnectData(int topicId)
            {
                _topics.Remove(topicId);
            }
    
            public int Heartbeat() { return 1; }
    
            public void ServerTerminate() { _timer.Dispose(); }
    
            [ComRegisterFunctionAttribute]
            public static void RegisterFunction(Type t)
            {
                Microsoft.Win32.Registry.ClassesRoot.CreateSubKey(@"CLSID\{" + t.GUID.ToString().ToUpper() + @"}\Programmable");
                var key = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(@"CLSID\{" + t.GUID.ToString().ToUpper() + @"}\InprocServer32", true);
                if (key != null)
                    key.SetValue("", System.Environment.SystemDirectory + @"\mscoree.dll", Microsoft.Win32.RegistryValueKind.String);
            }
    
            [ComUnregisterFunctionAttribute]
            public static void UnregisterFunction(Type t)
            {
                Microsoft.Win32.Registry.ClassesRoot.DeleteSubKey(@"CLSID\{" + t.GUID.ToString().ToUpper() + @"}\Programmable");
            }
        }
    }
 
