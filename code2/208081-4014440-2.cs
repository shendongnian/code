    using System;
    using System.Text;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    
    namespace EnumInstalledMsiProducts {
        internal static class NativeMethods {
            internal const int MaxGuidChars = 38;
            internal const int NoError = 0;
            internal const int ErrorNoMoreItems = 259;
            internal const int ErrorUnknownProduct = 1605;
            internal const int ErrorUnknownProperty = 1608;
            internal const int ErrorMoreData = 234;
    
            [DllImport ("msi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern int MsiEnumRelatedProducts (string lpUpgradeCode, int dwReserved,
                int iProductIndex, //The zero-based index into the registered products.
                StringBuilder lpProductBuf); // A buffer to receive the product code GUID.
                                             // This buffer must be 39 characters long.
            // The first 38 characters are for the GUID, and the last character is for
            // the terminating null character.
    
            [DllImport ("msi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            internal static extern Int32 MsiGetProductInfo (string product, string property,
                StringBuilder valueBuf, ref Int32 cchValueBuf);
        }
        class Program {
            static int GetProperty(string productCode, string propertyName, StringBuilder sbBuffer) {
                int len = sbBuffer.Capacity;
                sbBuffer.Length = 0;
                int status = NativeMethods.MsiGetProductInfo (productCode,
                                                              propertyName,
                                                              sbBuffer, ref len);
                if (status == NativeMethods.ErrorMoreData) {
                    len++;
                    sbBuffer.EnsureCapacity (len);
                    status = NativeMethods.MsiGetProductInfo (productCode, propertyName, sbBuffer, ref len);
                }
                if ((status == NativeMethods.ErrorUnknownProduct ||
                     status == NativeMethods.ErrorUnknownProperty)
                    && (String.Compare (propertyName, "ProductVersion", StringComparison.Ordinal) == 0 ||
                        String.Compare (propertyName, "ProductName", StringComparison.Ordinal) == 0)) {
                    // try to get vesrion manually
                    StringBuilder sbKeyName = new StringBuilder ();
                    sbKeyName.Append ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Installer\\UserData\\S-1-5-18\\Products\\");
                    Guid guid = new Guid (productCode);
                    byte[] buidAsBytes = guid.ToByteArray ();
                    foreach (byte b in buidAsBytes) {
                        int by = ((b & 0xf) << 4) + ((b & 0xf0) >> 4);  // swap hex digits in the byte
                        sbKeyName.AppendFormat ("{0:X2}", by);
                    }
                    sbKeyName.Append ("\\InstallProperties");
                    RegistryKey key = Registry.LocalMachine.OpenSubKey (sbKeyName.ToString ());
                    if (key != null) {
                        string valueName = "DisplayName";
                        if (String.Compare (propertyName, "ProductVersion", StringComparison.Ordinal) == 0)
                            valueName = "DisplayVersion";
                        string val = key.GetValue (valueName) as string;
                        if (!String.IsNullOrEmpty (val)) {
                            sbBuffer.Length = 0;
                            sbBuffer.Append (val);
                            status = NativeMethods.NoError;
                        }
                    }
                }
    
                return status;
            }
    
            static void Main () {
                string upgradeCode = "{00140000-001A-0000-0000-0000000FF1CE}";
                StringBuilder sbProductCode = new StringBuilder (39);
                StringBuilder sbProductName = new StringBuilder ();
                StringBuilder sbProductVersion = new StringBuilder (1024);
                for (int iProductIndex = 0; ; iProductIndex++) {
                    int iRes = NativeMethods.MsiEnumRelatedProducts (upgradeCode, 0, iProductIndex, sbProductCode);
                    if (iRes != NativeMethods.NoError) {
                        //  NativeMethods.ErrorNoMoreItems=259
                        break;
                    }
                    string productCode = sbProductCode.ToString();
                    int status = GetProperty (productCode, "ProductVersion", sbProductVersion);
                    if (status != NativeMethods.NoError) {
                        Console.WriteLine ("Can't get 'ProductVersion' for {0}", productCode);
                    }
                    status = GetProperty (productCode, "ProductName", sbProductName);
                    if (status != NativeMethods.NoError) {
                        Console.WriteLine ("Can't get 'ProductName' for {0}", productCode);
                    }
    
                    Console.WriteLine ("ProductCode: {0}{3}ProductName:'{1}'{3}ProductVersion:'{2}'{3}",
                                       productCode, sbProductName, sbProductVersion, Environment.NewLine);
                }
            }
        }
    }
