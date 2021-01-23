    using System;
    using System.IO;
    using System.Text;
    using System.Windows;
    using System.Management; //<-- right-click on project and add reference
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    // This Class implements Mount/Unmount for USB Removable Drives
    //  in a way similar to "Disk Manager" in the Control Panel.
    //
    //  Currently, It doesn't implement "Eject" like when you right
    //    right-click on the USB icon on lower right of screen.
    //    The "Unmount" is similar to "Eject" except it dosn't
    //    cleanup the registry so that the USB drive can be automatically
    //    recognized again without manually mounting it from "Disk Manager"
    //    If somebody knows how to fix this class to gain this function...
    //       please post it to their thread.  Thanks.
    namespace WPM {
	public struct UsbDriveItem_t {
		public string DeviceId;
		public char   DriveLetter;
		public string Label;
	};
	delegate void UsbEvent();
	class UsbDriveRemovable {
		public static int Unmount(char DriveLetter) {
			bool success = ValidateAdmin
                                    ("UsbDriveRemovable.Unmount()");
			if (!success) return -1;
			
			string Name = "'" + DriveLetter + ":\\\\'";
			
			string mq   = "SELECT * FROM Win32_Volume Where Name = " + Name;
			ManagementObjectSearcher ms 
                         = new ManagementObjectSearcher(mq);
			ManagementObjectCollection mc = ms.Get();
			foreach (ManagementObject mo in mc) {
				var DriveLetterI  = mo["DriveLetter"].ToString();
				mo["DriveLetter"] = null;
				mo.Put();
				ManagementBaseObject inParams = mo.GetMethodParameters("Dismount");
				inParams["Force"] = false;
				inParams["Permanent"] = false;
				ManagementBaseObject outParams = mo.InvokeMethod("Dismount", inParams, null);
				string rc = outParams["ReturnValue"].ToString();
				mo.Dispose();
			}
			mc.Dispose();
			ms.Dispose();
			return 0;
		}
		public static int Mount(string DeviceId, char Letter = '?') {
			bool success = ValidateAdmin("UsbDriveRemovable.Mount()");
			if (!success) return -1;
			if (Letter == '?' || Letter == '#') {
				GetFirstUnsedLetter(out Letter);
			}
			
			string FixDeviceId = Regex.Replace(DeviceId, @"\\", @"\\");
			
			string mq = "SELECT * FROM Win32_Volume WHERE DeviceId = '"
				+ FixDeviceId
				+ "'";
			
			ManagementObjectSearcher ms = new ManagementObjectSearcher(mq);
			ManagementObjectCollection mc = ms.Get();
			foreach (ManagementObject mo in mc) {
				ManagementBaseObject inParams = mo.GetMethodParameters("AddMountPoint");
				inParams["Directory"] = Letter + ":\\";
				ManagementBaseObject outParams = mo.InvokeMethod("AddMountPoint", inParams, null);
				string rc = outParams["ReturnValue"].ToString();
				mo.Dispose();
			}
			mc.Dispose();
			ms.Dispose();
			return 0;
		}
		
		/*List<UsbDriveItem_t>*/ 
		public static int ListDrives(ref List<UsbDriveItem_t> DriveList) {
			DriveList.Clear();
			string mq = "SELECT * FROM Win32_Volume Where DriveType = '2'";
			ManagementObjectSearcher ms   = new ManagementObjectSearcher(mq);
			ManagementObjectCollection mc = ms.Get();
			foreach (ManagementObject mo in mc) {
				UsbDriveItem_t item = new UsbDriveItem_t();
				item.Label       = (mo["Label"] == null)       ? "<none>" : mo["Label"].ToString();
				item.DriveLetter = (mo["DriveLetter"] == null) ? '#' : mo["DriveLetter"].ToString()[0];
				item.DeviceId    = (mo["DeviceId"] == null)    ? "<none>" : mo["DeviceId"].ToString();
				DriveList.Add(item);
				mo.Dispose();
			}
			mc.Dispose();
			ms.Dispose();
			
			return 0;
		}
		
		public static int GetFirstUnsedLetter(out char Letter) {
			bool[] alphabet = new bool[26];
			
			for (int i=0; i < 26; i++) {
				alphabet[i] = false;
			}
			
			string mq = "SELECT * FROM Win32_Volume";
			ManagementObjectSearcher ms   = new ManagementObjectSearcher(mq);
			ManagementObjectCollection mc = ms.Get();
			foreach (ManagementObject mo in mc) {
				if (mo["DriveLetter"] != null) {
					char cc      = mo["DriveLetter"].ToString()[0];
					int  ci      = char.ToUpper(cc) - 65;
					alphabet[ci] = true;
				}
				mo.Dispose();
			}
			mc.Dispose();
			ms.Dispose();
			
			int found = -1;
			for (int i=3; i < 26; i++) {
				if (alphabet[i] == false) {
					found = i;
					break;
				}
			}
			
			if (found >= 0) {
				Letter = (char)(found + 65);
				return 0;
			}
			else {
				Letter = '?';
				return -1;
			}
		}
		
		
		public static ManagementEventWatcher
			RegisterInsertEvent(UsbEvent InsertEvent) {
			var insertQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 2");
			var insertWatcher = new ManagementEventWatcher(insertQuery);			
			insertWatcher.EventArrived += delegate(object sender, EventArrivedEventArgs e) {
				// string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();				
				Action action = delegate {
					InsertEvent();
				};
				Application.Current.Dispatcher.BeginInvoke(action);
			};
			insertWatcher.Start();
			return insertWatcher;
		}
		public static ManagementEventWatcher RegisterRemoveEvent(UsbEvent RemoveEvent) {
			var removeQuery = new WqlEventQuery("SELECT * FROM Win32_DeviceChangeEvent WHERE EventType = 3");
			var removeWatcher = new ManagementEventWatcher(removeQuery);
			removeWatcher.EventArrived += delegate(object sender, EventArrivedEventArgs e) {
				// string driveName = e.NewEvent.Properties["DriveName"].Value.ToString();				
				Action action = delegate {					
					RemoveEvent();
				};
				Application.Current.Dispatcher.BeginInvoke(action);
			};
			removeWatcher.Start();
			return removeWatcher;
		}
		
		// Mount all UsbRemovable Drives that are not currently mounted
		public static int MountAll() {
			List<UsbDriveItem_t> DriveList = new List<UsbDriveItem_t>();
			ListDrives(ref DriveList);
			
			foreach (UsbDriveItem_t item in DriveList) {
				if (item.DriveLetter == '?') {
					Mount(item.DeviceId);
				}
			}
			return 0;
		}
		// Unmount all UsbRemovable Drives
		public static int UnmountAll() {
			List<UsbDriveItem_t> DriveList = new List<UsbDriveItem_t>();
			ListDrives(ref DriveList);
			
			foreach (UsbDriveItem_t item in DriveList) {
				if (item.DriveLetter != '?') {
					Unmount(item.DriveLetter);
				}
			}
			return 0;
		}
		
		public static bool IsAdministrator()
		{
			var id   = System.Security.Principal.WindowsIdentity.GetCurrent();
			var prin = new System.Security.Principal.WindowsPrincipal(id);
			return prin.IsInRole(
				System.Security.Principal.WindowsBuiltInRole.Administrator);
		}
		public static bool ValidateAdmin(string CalledFrom = null) {
			if (CalledFrom == null) {
				CalledFrom = "";
			}
			if (!IsAdministrator()) {
				string msg = "Please rerun this application with admin privileges.\r\n\r\n"
				+ "Access denied to call " + CalledFrom + "\r\n\r\n";
				MessageBox.Show(msg, "ERROR");
				return false;
			}
			return true;
		}
		
		public static void StartExplorer(char DriveLetter) 
		{
			var proc1 = new System.Diagnostics.Process();
			proc1.StartInfo.FileName               = @"C:\\Windows\\System32\\explorer.exe";
			proc1.StartInfo.Arguments              = DriveLetter.ToString();
			proc1.StartInfo.CreateNoWindow         = true;
			proc1.StartInfo.UseShellExecute        = false;
			proc1.StartInfo.RedirectStandardOutput = true;
			proc1.StartInfo.RedirectStandardError  = true;
			proc1.Start();
			proc1.WaitForExit();
			string proc1out = proc1.StandardOutput.ReadToEnd();
			string proc1err = proc1.StandardError.ReadToEnd();
			//if (proc1.ExitCode != 0) {
			//	string msg = proc1out + "\r\n\r\n" + proc1err;
			//	MessageBox.Show(msg, "Error: Mountvol /R");
			//}
			proc1.Close();					
		}		
		
	} //class
    } //namespace
    /*  DOESN'T WORK WELL...
		// Kludge to get USB Drive to be recognized again
		void UsbCleanup() {
			var proc1 = new System.Diagnostics.Process();
			proc1.StartInfo.FileName               = @"C:\\Windows\\System32\\mountvol.exe";
			proc1.StartInfo.Arguments              = @"/R";
			proc1.StartInfo.CreateNoWindow         = true;
			proc1.StartInfo.UseShellExecute        = false;
			proc1.StartInfo.RedirectStandardOutput = true;
			proc1.StartInfo.RedirectStandardError  = true;
			proc1.Start();
			proc1.WaitForExit();
			string proc1out = proc1.StandardOutput.ReadToEnd();
			string proc1err = proc1.StandardError.ReadToEnd();
			if (proc1.ExitCode != 0) {
				string msg = proc1out + "\r\n\r\n" + proc1err;
				MessageBox.Show(msg, "Error: Mountvol /R");
			}
			proc1.Close();
			var proc2 = new System.Diagnostics.Process();
			proc2.StartInfo.FileName               = @"C:\\Windows\\System32\\mountvol.exe";
			proc2.StartInfo.Arguments              = @"/E";
			proc2.StartInfo.CreateNoWindow         = true;
			proc2.StartInfo.UseShellExecute        = false;
			proc2.StartInfo.RedirectStandardOutput = true;
			proc2.StartInfo.RedirectStandardError  = true;
			proc2.Start();
			proc2.WaitForExit();
			string proc2out = proc2.StandardOutput.ReadToEnd();
			string proc2err = proc2.StandardError.ReadToEnd();
			if (proc2.ExitCode != 0) {
				string msg = proc1out + "\r\n\r\n" + proc1err;
				MessageBox.Show(msg, "Error: Mountvol /E");
			}
			proc2.Close();
			return;
		}
    */
