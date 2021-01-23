    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Linq;
    using System.Windows.Forms;
    using System.Reflection;
    
    namespace Rdp.Interfaces {
    
        /************************************************************************************************/
        /*                                  struct  members                                             */
        /************************************************************************************************/
        /// <summary>
        /// Terminal Session Info data holder struct.
        /// </summary>
        /// <remarks>
        /// Structures, interfaces, p-invoke members for Terminal Service Session
        /// </remarks>
        [Serializable]
        public struct TerminalSessionInfo {
            /// <summary>
            ///  Remote Desktop Services API Structure member
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_SESSION_INFO"/>
            public WTS_SESSION_INFO SessionInfo;
            /// <summary>
            ///  Remote Desktop Services API Structure member
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_PROTOCOL_TYPE"/>
            public WTS_CLIENT_PROTOCOL_TYPE ProtocolType;
            /// <summary>
            ///  Remote Desktop Services API Structure member
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTS_CLIENT_INFO"/>
            public WTS_CLIENT_INFO ClientInfo;
            /// <summary>
            ///  Remote Desktop Services API Structure member
            /// </summary>
            /// <seealso cref="T:Oerlikon.Balzers.Rdp.Interfaces.WTSINFO"/>
            public WTSINFO WtsInfo;
            /// <summary>
            ///  The client user name.
            /// </summary>
            public string UserName;
            /// <summary>
            ///  The domain name of the client computer.
            /// </summary>
            public string Domain;
            /// <summary>
            /// The client network address.
            /// </summary>
            public string ClientIPAddress;
            /// <summary>
            /// The machine name of the client computer.
            /// </summary>
            public string ClientMachineName;
    
            /// <summary>
            /// Initializes a new instance of the <see cref="T:Oerlikon.Balzers.Rdp.Interfaces.TerminalSessionInfo"/> structure.
            /// </summary>
            /// <param name="SessionId">Only used to force an initialization of members.</param>
            public TerminalSessionInfo(int SessionId) {
                this.SessionInfo = new WTS_SESSION_INFO();
                this.SessionInfo.iSessionID = SessionId;
                this.SessionInfo.sWinsWorkstationName = String.Empty;
                this.UserName = String.Empty;
                this.Domain = String.Empty;
                this.ClientIPAddress = String.Empty;
                this.ProtocolType = WTS_CLIENT_PROTOCOL_TYPE.UNKNOWN;
                this.ClientMachineName = String.Empty;
                this.ClientInfo = new WTS_CLIENT_INFO();
                this.ClientInfo.ClientMachineName = String.Empty;
                this.ClientInfo.Domain = String.Empty;
                this.ClientInfo.UserName = String.Empty;
                this.ClientInfo.WorkDirectory = String.Empty;
                this.ClientInfo.InitialProgram = String.Empty;
                this.ClientInfo.ClientDirectory = String.Empty;
                this.ClientInfo.DeviceId = String.Empty;
                this.WtsInfo = new WTSINFO();
                this.WtsInfo.Domain = String.Empty;
                this.WtsInfo.UserName = String.Empty;
                this.WtsInfo.WinStationName = String.Empty;
            }
    
            /// <summary>
            /// Returns the fully qualified type name of this instance.
            /// </summary>
            /// <returns>
            /// A <see cref="T:System.String"/> containing a fully qualified type name.
            /// </returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString() {
                string retval = "SessionID: " + this.SessionInfo.iSessionID.ToString();
                retval += String.IsNullOrEmpty(this.Domain) ? "" : Environment.NewLine + "Domain: " + this.Domain;
                retval += String.IsNullOrEmpty(this.UserName) ? "" : Environment.NewLine + "UserName: " + this.UserName;
                retval += String.IsNullOrEmpty(this.ClientMachineName) ? "" : Environment.NewLine + "ClientMachineName: " + this.ClientMachineName;
                retval += String.IsNullOrEmpty(this.ClientIPAddress) ? "" : Environment.NewLine + "ClientIPAddress: " + this.ClientIPAddress;
                retval += String.IsNullOrEmpty(this.SessionInfo.sWinsWorkstationName) ? "" : Environment.NewLine + "WinsWorkstationName: " + this.SessionInfo.sWinsWorkstationName;
                retval += this.ProtocolType == WTS_CLIENT_PROTOCOL_TYPE.UNKNOWN ? "" : Environment.NewLine + "ProtocolType: " + this.ProtocolType.ToString();
                retval += String.IsNullOrEmpty(this.SessionInfo.oState.ToString()) ? "" : Environment.NewLine + "State: " + this.SessionInfo.oState.ToString();
                retval += String.IsNullOrEmpty(this.ClientInfo.ClientMachineName) ? "" : Environment.NewLine + "ClientInfoMachineName: " + this.ClientInfo.ClientMachineName;
                retval += String.IsNullOrEmpty(this.ClientInfo.Domain) ? "" : Environment.NewLine + "ClientInfoDomain: " + this.ClientInfo.Domain;
                retval += String.IsNullOrEmpty(this.ClientInfo.UserName) ? "" : Environment.NewLine + "ClientInfoUserName: " + this.ClientInfo.UserName;
                retval += String.IsNullOrEmpty(this.ClientInfo.WorkDirectory) ? "" : Environment.NewLine + "ClientInfoWorkDirectory: " + this.ClientInfo.WorkDirectory;
                retval += String.IsNullOrEmpty(this.ClientInfo.ClientDirectory) ? "" : Environment.NewLine + "ClientInfoDirectory: " + this.ClientInfo.ClientDirectory;
                retval += String.IsNullOrEmpty(this.ClientInfo.DeviceId) ? "" : Environment.NewLine + "ClientInfoDeviceId: " + this.ClientInfo.DeviceId;
                retval += this.ClientInfo.ClientBuildNumber == 0 ? "" : Environment.NewLine + "ClientInfoBuildNumber: " + this.ClientInfo.ClientBuildNumber.ToString();
                retval += this.ClientInfo.ClientHardwareId == 0 ? "" : Environment.NewLine + "ClientInfoHardwareId: " + this.ClientInfo.ClientHardwareId.ToString();
                retval += this.ClientInfo.ClientProductId == 0 ? "" : Environment.NewLine + "ClientInfoProductId: " + this.ClientInfo.ClientProductId.ToString();
                retval += String.IsNullOrEmpty(this.WtsInfo.Domain) ? "" : Environment.NewLine + "WtsInfoDomain: " + this.WtsInfo.Domain;
                retval += String.IsNullOrEmpty(this.WtsInfo.UserName) ? "" : Environment.NewLine + "WtsInfoUserName: " + this.WtsInfo.UserName;
                retval += String.IsNullOrEmpty(this.WtsInfo.WinStationName) ? "" : Environment.NewLine + "WtsInfoWinStationName: " + this.WtsInfo.WinStationName;
                retval += this.WtsInfo.ConnectTime == 0 ? "" : Environment.NewLine + "WtsInfoConnectTime: " + ToCSharpTime(this.WtsInfo.ConnectTime, true).ToString();
                retval += this.WtsInfo.CurrentTime == 0 ? "" : Environment.NewLine + "WtsInfoCurrentTime: " + ToCSharpTime(this.WtsInfo.CurrentTime, true).ToString();
                retval += this.WtsInfo.DisconnectTime == 0 ? "" : Environment.NewLine + "WtsInfoDisconnectTime: " + ToCSharpTime(this.WtsInfo.DisconnectTime, true).ToString();
                retval += this.WtsInfo.LogonTime == 0 ? "" : Environment.NewLine + "WtsInfoLogonTime: " + ToCSharpTime(this.WtsInfo.LogonTime, true).ToString();
                retval += this.WtsInfo.LastInputTime == 0 ? "" : Environment.NewLine + "WtsInfoLogonTime: " + ToCSharpTime(this.WtsInfo.LastInputTime, true).ToString();
                retval += this.WtsInfo.IncomingBytes == 0 ? "" : Environment.NewLine + "WtsInfoIncomingBytes: " + this.WtsInfo.IncomingBytes.ToString();
                retval += this.WtsInfo.OutgoingBytes == 0 ? "" : Environment.NewLine + "WtsInfoOutgoingBytes: " + this.WtsInfo.OutgoingBytes.ToString();
                return retval;
            }
    
            /// <summary>
            /// Help method to find C++ corresponding long value of C# DateTime (starting at 01
            /// / 01 / 1970 00:00:00).
            /// </summary>
            /// <param name="date">.NET object</param>
            /// <param name="localTime">If set to <see langword="true"/>, then date will be
            /// assummed as local time and converted to UTC - time; otherwise, UTC will be
            /// assumed.</param>
            /// <returns>
            /// C++ corresponding long value
            /// </returns>
            public static long ToUnixtime(DateTime date, bool localTime) {
                DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //DateTime unixStartTime = DateTime.MinValue;
                if(localTime) date = date.ToUniversalTime();
                TimeSpan timeSpan = date - unixStartTime;
                return Convert.ToInt64(timeSpan.TotalMilliseconds);
            }
    
            /// <summary>
            ///  Help method to find C# DateTime from C++ corresponding long value.
            /// </summary>
            /// <param name="unixTime">Unix value of date time starting at 01 / 01 / 1970
            /// 00:00:00</param>
            /// <param name="localTime">If set to <see langword="true"/>, then ; otherwise,
            /// .</param>
            public static DateTime ToCSharpTime(long unixTime, bool localTime) {
                DateTime unixStartTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
                //DateTime unixStartTime = DateTime.MinValue;           
                if(localTime) return unixStartTime.AddTicks(unixTime).ToLocalTime();
                return unixStartTime.AddTicks(unixTime);
            }
    
            #region IComparable Members
    
            /// <summary>
            /// Overriding Operator ==
            /// </summary>
            /// <param name="a">Object to compare</param>
            /// <param name="b">Object to compare</param>
            /// <returns>Return true if the segment start / end values match.</returns>
            public static bool operator ==(TerminalSessionInfo a, TerminalSessionInfo b) {
                return Equals(a, b);
            }
    
            /// <summary>
            /// Overriding Operator !=
            /// </summary>
            /// <param name="a">Object to compare</param>
            /// <param name="b">Object to compare</param>
            /// <returns>Return true if the segment start / end values match.</returns>
            public static bool operator !=(TerminalSessionInfo a, TerminalSessionInfo b) {
                return !Equals(a, b);
            }
    
            /// <summary>
            /// Overriding Equals
            /// </summary>
            /// <param name="obj">Object to compare with own instance.</param>
            /// <returns>Return true if the segment start / end values match.</returns>
            public override bool Equals(object obj) {
                // If parameter is null return false.
                if(obj == null) {
                    return false;
                }
                // If parameter cannot be cast to Point return false.
                TerminalSessionInfo p = (TerminalSessionInfo)obj;
                if((System.Object)p == null) {
                    return false;
                }
    
                // Return true if the segment start / end values match: 
                return Equals(this, p);
            }
    
    
            /// <summary>
            /// Memberwise comparison
            /// </summary>
            /// <param name="a"></param>
            /// <param name="b"></param>
            public static bool Equals(TerminalSessionInfo a, TerminalSessionInfo b) {
                bool retval = false;
                if(((System.Object)a == null) && (System.Object)b == null) {
                    return false;
                }
                if(((System.Object)a == null) ^ (System.Object)b == null) {
                    return false;
                }
    
                // check property members         
                string[] properties = new string[] { 
                    "UserName", 
                    "Domain",
                    "ClientIPAddress",
                    "ClientMachineName",
                    "SessionInfo.iSessionID",
                    "SessionInfo.sWinsWorkstationName",
                    "SessionInfo.oState",
                    "ProtocolType",
                    "ClientInfo.ClientMachineName",
                    "ClientInfo.Domain",
                    "ClientInfo.UserName",
                    "ClientInfo.WorkDirectory",
                    "ClientInfo.InitialProgram",
                    "ClientInfo.EncryptionLevel",
                    "ClientInfo.ClientAddressFamily",
                    "ClientInfo.ClientAddress",
                    "ClientInfo.HRes",
                    "ClientInfo.VRes",
                    "ClientInfo.ColorDepth",
                    "ClientInfo.ClientDirectory",
                    "ClientInfo.ClientBuildNumber",
                    "ClientInfo.ClientHardwareId",
                    "ClientInfo.ClientProductId",
                    "ClientInfo.DeviceId",
                    "WtsInfo.State",
                    "WtsInfo.SessionId",
                    "WtsInfo.WinStationName",
                    "WtsInfo.Domain",
                    "WtsInfo.UserName",
                    "WtsInfo.ConnectTime",
                    "WtsInfo.DisconnectTime",
                    "WtsInfo.LogonTime" };
    
                retval = true;
                object vala, valb;
                foreach(string prop in properties) {
                    try {
                        vala = GetFieldItem(a, prop);
                        valb = GetFieldItem(b, prop);
                        if(((System.Object)vala == null) && (System.Object)valb == null)
                            continue;                  
                        if(((System.Object)vala == null) ^ (System.Object)valb == null) 
                            return false;
    
                        if(!Object.Equals(vala, valb))
                            return false;
                    }
                    catch(Exception ex) {
                        retval = false;
                    }
    
                }
                return retval;
            }
            
            /* Ein Property TopDown suchen. Wir graben uns durch die Hierarchiestufen einer Klasse nach unten,
            // Bis wir das erste mal auf das Property "name" stossen. Dieses wird dann zurückgemolden
            // Bei überladenen Properties wird dann erst das überladene gefunden.
            // Über den normalen Type.GetProperty(name) würde sonst ein ambigous error erzeugt.*/
            /// <summary>
            /// Gets property with path <see paramref="name"/> from <see paramref="obj"/>.
            /// Using System.Type.GetProperty(name) throws an exception if a property is overloaded. This method
            /// does not throw an ambigous exception instead it returns the overloaded property value.
            /// </summary>
            /// <param name="obj">Object with properties.</param>
            /// <param name="name">Path to property (e.g.: TimeOfDay.Hours or Ticks)</param>
            /// <returns></returns>
            static public System.Reflection.PropertyInfo GetPropertyTopDown(System.Object obj, System.String name) {
                System.Type trs = obj.GetType();
                for(trs = obj.GetType(); trs != null; trs = trs.BaseType) {
                    // Nur Properties, die in dieser Hierarchiestufe der Klasse deklariert wurden
                    System.Reflection.PropertyInfo[] pis = trs.GetProperties(
                        System.Reflection.BindingFlags.Public
                        | System.Reflection.BindingFlags.Instance
                        | System.Reflection.BindingFlags.DeclaredOnly
                        | System.Reflection.BindingFlags.NonPublic
                        | System.Reflection.BindingFlags.Static);
    
                    foreach(System.Reflection.PropertyInfo pi in pis) {
                        System.Diagnostics.Debug.Assert(trs == pi.DeclaringType);
                        if(pi.Name == name) {
                            //System.Diagnostics.Debug.WriteLine(pi.DeclaringType + " -> " + pi.Name);
                            return pi;
                        }
                    }
                }
                return null;
            }
    
            /* Ein Property TopDown suchen. Wir graben uns durch die Hierarchiestufen einer Klasse nach unten,
          // Bis wir das erste mal auf das Property "name" stossen. Dieses wird dann zurückgemolden
          // Bei überladenen Properties wird dann erst das überladene gefunden.
          // Über den normalen Type.GetProperty(name) würde sonst ein ambigous error erzeugt.*/
            /// <summary>
            /// Gets property with path <see cref=""/> from <see cref=""/>. Using
            /// System.Type.GetField(name) throws an exception if a property is overloaded. This
            /// method does not throw an ambigous exception instead it returns the overloaded
            /// property value.
            /// </summary>
            /// <param name="obj">Object with properties.</param>
            /// <param name="name">Path to property (e.g.: TimeOfDay.Hours or Ticks)</param>
            static public System.Reflection.FieldInfo GetFieldTopDown(System.Object obj, System.String name) {
                System.Type trs = obj.GetType();
                for(trs = obj.GetType(); trs != null; trs = trs.BaseType) {
                    // Nur Properties, die in dieser Hierarchiestufe der Klasse deklariert wurden
                    System.Reflection.FieldInfo[] pis = trs.GetFields(
                        System.Reflection.BindingFlags.Public
                        | System.Reflection.BindingFlags.Instance
                        | System.Reflection.BindingFlags.DeclaredOnly
                        | System.Reflection.BindingFlags.NonPublic
                        | System.Reflection.BindingFlags.Static);
    
                    foreach(System.Reflection.FieldInfo fi in pis) {
                        System.Diagnostics.Debug.Assert(trs == fi.DeclaringType);
                        if(fi.Name == name) {
                            //System.Diagnostics.Debug.WriteLine(pi.DeclaringType + " -> " + pi.Name);
                            return fi;
                        }
                    }
                }
                return null;
            }
    
            /// <summary>
            /// Gets value of property with path <paramref name="name"/>.
            /// </summary>
            /// <param name="obj">Object with properties.</param>
            /// <param name="name">Property path.</param>
            /// <example>
            /// 	<code><![CDATA[
            /// System.DateTime date = new System.DateTime();
            /// int hours = (int)Balzers.Misc.ReflectionHelper.GetItem(date, "TimeOfDay.Hours");
            /// long ticks = (long)Balzers.Misc.ReflectionHelper.GetItem(date, "Ticks");
            /// ]]></code>
            /// </example>
            static public System.Object GetFieldItem(System.Object obj, System.String name) {
                System.Reflection.FieldInfo fi = null;
                System.String[] s = name.Split(new char[] { '.' }, 2);
                while(s.Length > 1) {
                    //pi = Balzers.Misc.ReflectionHelper.GetPropertyTopDown(obj, name);
                    //System.Diagnostics.Debug.Assert(pi != null, "GetItem(obj, " + name + ")");
                    fi = GetFieldTopDown(obj, s[0]);
                    System.Diagnostics.Debug.Assert(fi != null, "GetFieldItem(obj, " + name + ")");
                    obj = fi.GetValue(obj);
                    //obj = obj.GetType().GetProperty(s[0]).GetValue(obj, null);
                    s = s[1].Split(new char[] { '.' }, 2);
                }
    
                //pi = Balzers.Misc.ReflectionHelper.GetPropertyTopDown(obj, name);
                //System.Diagnostics.Debug.Assert(pi != null, "GetItem(obj, " + name + ")");
                fi = GetFieldTopDown(obj, s[0]);
                System.Diagnostics.Debug.Assert(fi != null, "GetFieldItem(obj, " + s[0] + ")");
                System.Object value = fi.GetValue(obj);
                return value;
                //return obj.GetType().GetProperty(s[0]).GetValue(obj, null);
            }
    
            #endregion
        }
	}
