				using System;
				using System.ComponentModel;
				using System.IO.Ports;
				using System.Reflection;
				using System.Runtime.InteropServices;
				using System.Security;
				using System.Security.Permissions;
				using Microsoft.Win32.SafeHandles;
				class Program
				{
					static void Main(string[] args)
					{
						using (var port = new SerialPort("COM1"))
						{
							port.Open();
							port.SetXonXoffChars(0x12, 0x14);
						}
					}
				}
				internal static class SerialPortExtensions
				{
					[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
					public static void SetXonXoffChars(this SerialPort port, byte xon, byte xoff)
					{
						if (port == null)
							throw new NullReferenceException();
						if (port.BaseStream == null)
							throw new InvalidOperationException("Cannot change X chars until after the port has been opened.");
						try
						{
							// Get the base stream and its type which is System.IO.Ports.SerialStream
							object baseStream = port.BaseStream;
							Type baseStreamType = baseStream.GetType();
							// Get the Win32 file handle for the port
							SafeFileHandle portFileHandle = (SafeFileHandle)baseStreamType.GetField("_handle", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(baseStream);
							// Get the value of the private DCB field (a value type)
							FieldInfo dcbFieldInfo = baseStreamType.GetField("dcb", BindingFlags.NonPublic | BindingFlags.Instance);
							object dcbValue = dcbFieldInfo.GetValue(baseStream);
							// The type of dcb is Microsoft.Win32.UnsafeNativeMethods.DCB which is an internal type. We can only access it through reflection.
							Type dcbType = dcbValue.GetType();
							dcbType.GetField("XonChar").SetValue(dcbValue, xon);
							dcbType.GetField("XoffChar").SetValue(dcbValue, xoff);
							// We need to call SetCommState but because dcbValue is a private type, we don't have enough
							//  information to create a p/Invoke declaration for it. We have to do the marshalling manually.
							// Create unmanaged memory to copy DCB into
							IntPtr hGlobal = Marshal.AllocHGlobal(Marshal.SizeOf(dcbValue));
							try
							{
								// Copy their DCB value to unmanaged memory
								Marshal.StructureToPtr(dcbValue, hGlobal, false);
								// Call SetCommState
								if (!SetCommState(portFileHandle, hGlobal))
									throw new Win32Exception(Marshal.GetLastWin32Error());
								// Update the BaseStream.dcb field if SetCommState succeeded
								dcbFieldInfo.SetValue(baseStream, dcbValue);
							}
							finally
							{
								if (hGlobal != IntPtr.Zero)
									Marshal.FreeHGlobal(hGlobal);
							}
						}
						catch (SecurityException) { throw; }
						catch (OutOfMemoryException) { throw; }
						catch (Win32Exception) { throw; }
						catch (Exception ex)
						{
							throw new ApplicationException("SetXonXoffChars has failed due to incorrect assumptions about System.IO.Ports.SerialStream which is an internal type.", ex);
						}
					}
					[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
					private static extern bool SetCommState(SafeFileHandle hFile, IntPtr lpDCB);
				}
