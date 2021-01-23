    using Microsoft.Win32;
    using System;
    
    namespace RetrieveAudioDeviceInfo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string RequestedDeviceStatus = "Active"; // Initialize string variable for storing audio device status of interest. Valid input = "Active" or "Enabled"
                string RequestedDeviceType = "Playback"; // Initialize string variable for storing audio device type of interest. Valid input = "Playback" or "Recording"
                
                if (!String.Equals(RequestedDeviceStatus, "Active", StringComparison.OrdinalIgnoreCase) && !String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check RequestedDeviceStatus to ensure valid input was provided
                {
                    Console.WriteLine("Invalid AudioDeviceStatus specified. Info request canceled"); // Output info to event log
                    Console.ReadLine(); // Wait for user input
                    return; // Immediately stop processing the inline function
                }
                string DeviceRegistryName; // Declare string variable for storing the registry name for the device type of interest
    
                if (String.Equals(RequestedDeviceType, "Playback", StringComparison.OrdinalIgnoreCase)) // Check if info request is for playback devices
                    DeviceRegistryName = "Render"; // Set the DeviceRegistryName
                else if (String.Equals(RequestedDeviceType, "Recording", StringComparison.OrdinalIgnoreCase)) // Check if info request is for recording devices
                    DeviceRegistryName = "Capture"; // Set the DeviceRegistryName
                else
                {
                    Console.WriteLine("Invalid AudioDeviceType specified. Info request canceled"); // Output info to event log
                    Console.ReadLine(); // Wait for user input
                    return; // Immediately stop processing the inline function
                }
                RegistryKey RootKey; // Initialize RegistryKey for containing the root (base) key to evaluate
    
                if (Environment.Is64BitOperatingSystem) // Check if operating system is 64-bit
                    RootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64); // Opens registry's LocalMachine key with a 64-bit view
                else
                    RootKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32); // Opens registry's LocalMachine key with a 32-bit view
                string AudioKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio"; // Parent registry key for audio devices
                string DeviceName, DeviceType; // Declare string variables for storing audio device information
                string[] ActiveDeviceRoles = null; // Initialize string array for storing information about the active devices for each audio role
    
                using (RegistryKey ChildKey = RootKey.OpenSubKey(AudioKey)) // Open subkey of AudioKey and store in ChildKey. "using" implemented for proper disposal.
                {
                    foreach (string ChildKeyName in ChildKey.GetSubKeyNames()) // Loop through each SubKeyName in ChildKey
                    {
                        if (ChildKeyName == DeviceRegistryName) // Check if ChildKeyName is "Render" (signifies registry folder for audio playback devices)
                        {
                            using (RegistryKey RenderKey = ChildKey.OpenSubKey(ChildKeyName)) // Open subkey of ChildKey and store in RenderKey. "using" implemented for proper disposal.
                            {
                                DateTime[] ActiveDeviceRoleTimes = null; // Initialize DateTime array for storing times when audio devices last held a particular audio role
                                int j = 1; // Initialize integer variable for tracking audio playback device count
                                foreach (string DeviceKeyName in RenderKey.GetSubKeyNames()) // Loop through each SubKeyName in RenderKey
                                {
                                    using (RegistryKey DeviceKey = RenderKey.OpenSubKey(DeviceKeyName)) // Open subkey of RenderKey and store in DeviceKey. "using" implemented for proper disposal.
                                    {
                                        if (Convert.ToInt32(DeviceKey.GetValue("DeviceState")) == 1) // Check if current audio device is enabled
                                        {
                                            string CurrentDeviceInfo; // Declare string variable for storing information about the current audio device
                                            using (RegistryKey DeviceKeyProperties = DeviceKey.OpenSubKey("Properties")) // Open "Properties" subkey of DeviceKey and store in DeviceKeyProperties. "using" implemented for proper disposal.
                                            {
                                                DeviceName = DeviceKeyProperties.GetValue("{b3f8fa53-0004-438e-9003-51a46e139bfc},6").ToString(); // Retrieve the current device's name from the registry
                                                DeviceType = DeviceKeyProperties.GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0},2").ToString(); // Retrieve the current device's type from the registry
                                                CurrentDeviceInfo = DeviceType + " (" + DeviceName + ")"; // Combine the DeviceName and DeviceType info similar to how VoiceAttack displays this data in the Options menu
                                                if (String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check if user wants to show which audio devices are enabled
                                                {
                                                    Console.WriteLine("Audio " + RequestedDeviceType + " Device " + j++ + " = " + CurrentDeviceInfo); // Output the CurrentDeviceInfo to the event log
                                                    continue; // Continue with next index in parent for loop
                                                }
                                            }
    
                                            string[] roles = { "Role:0", "Role:1", "Role:2" }; // Initialize string array for storing the names of the different audio roles
                                            DateTime[] CurrentDeviceRoleTimes = new DateTime[roles.Length]; // Initialize DateTime array for storing times when the current audio devices last held a particular audio role
                                            //Console.WriteLine("Audio " + RequestedDeviceType + " Device " + j++ + " = " + CurrentDeviceInfo); // Output the CurrentDeviceInfo to the event log. Useful for debuging
                                            for (int i = 0; i < roles.Length; i++) // Loop based on the size of the roles string array
                                            {
                                                byte[] RegistryData = (byte[])DeviceKey.GetValue(roles[i]); // Extract audio device role data from the registry
                                                if (RegistryData == null) // Check if the extracted data is null
                                                    continue; // Continue to next index in parent for loop
                                                CurrentDeviceRoleTimes[i] = GetRoleDateTime(RegistryData); // Retrieve role information from registry, convert this data to a DateTime, and store it
                                                //Console.WriteLine(roles[i] + " = " + CurrentDeviceRoleTimes[i].ToString()); // Output info to event log. Useful for debuging
                                            }
                                            if (ActiveDeviceRoles == null || ActiveDeviceRoles.Length == 0) // Check if ActiveDeviceRoles is null or empty
                                            {
                                                ActiveDeviceRoles = new string[roles.Length]; // Initialize ActiveDeviceRoles string array
                                                ActiveDeviceRoleTimes = new DateTime[roles.Length]; // Initialize ActiveDeviceRoleTImes DateTime array
                                            }
                                            for (int i = 0; i < roles.Length; i++) // Loop based on the size of the roles string array 
                                            {
                                                if (ActiveDeviceRoleTimes[i] < CurrentDeviceRoleTimes[i]) // Check if the ActiveDeviceRoleTime at the current index is less than the CurrentDeviceRoleTime at this index
                                                {
                                                    ActiveDeviceRoles[i] = CurrentDeviceInfo; // Set ActiveDeviceRoles at current index to CurrentDeviceInfo
                                                    ActiveDeviceRoleTimes[i] = CurrentDeviceRoleTimes[i]; // Set ActiveDeviceRoleTime at current index to corresponding CurrentDeviceRoleTime at this index
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!String.Equals(RequestedDeviceStatus, "Enabled", StringComparison.OrdinalIgnoreCase)) // Check if user does NOT want to see the enabled devices
                {
                    if (ActiveDeviceRoles != null) // Check if ActiveDeviceRoles is not null (i.e., enabled device data has been found and stored)
                    {
                        for (int i = 0; i < ActiveDeviceRoles.Length; i++) // Loop based on the size of the ActiveDeviceRoles string array
                        {
                            string RoleName = null; // Initialize string variable for storing role description
                            switch (i) // Create switch statement based on integer i
                            {
                                case 0: // For case where i = 0
                                    RoleName = "Default"; // Set RoleName
                                    break; // Break out of switch statement
                                case 1: // For case where i = 1
                                        // There is the "Multimedia" role, but I don't believe this is currently used by Windows. 
                                        // The code for this role will remain for possible future use.
                                        //RoleName = "Multimedia"; // Set RoleName
                                        //break; // Break out of switch statement
                                    continue; // Immediately continue with next index in parent for loop
                                case 2: // For case where i = 2
                                    RoleName = "Communications"; // Set RoleName
                                    break; // Break out of switch statement
                            }
    
                            if (ActiveDeviceRoles[i] == null) // Check if ActiveDeviceRole at current index is null
                                Console.WriteLine("{0} {1} Device = {2}", RoleName, RequestedDeviceType, "Not Set"); // Output info to event log
                            else
                                Console.WriteLine("{0} {1} Device = {2}", RoleName, RequestedDeviceType, ActiveDeviceRoles[i]); // Output info to event log
                        }
                    }
                    else
                        Console.WriteLine("No audio playback devices enabled"); // Output info to event log
                }
                Console.ReadLine();
            }
    
            // Function for converting registry data for an audio device into corresponding DateTime information
            static DateTime GetRoleDateTime(byte[] binary)
            {
                if (binary == null || binary.Length != 16) // Check if binary is null or the length is not 16
                    throw new ArgumentException("Error converting registry data to DateTime"); // Throw an exception
    
                int year = Convert.ToInt32(binary[0] + binary[1]*256); // Extract year from registy data
                int month = Convert.ToInt32(binary[2]); // Extract month from registy data
                int day = Convert.ToInt32(binary[6]); // Extract day from registy data
                int hour = Convert.ToInt32(binary[8]); // Extract hour from registy data
                int minute = Convert.ToInt32(binary[10]); // Extract minute from registy data
                int seconds = Convert.ToInt32(binary[12]); // Extract seconds from registy data
                int milliseconds = Convert.ToInt32(binary[14] + binary[15]*256); // Extract milliseconds from registy data
                return new DateTime(year, month, day, hour, minute, seconds, milliseconds).ToLocalTime(); // Return the converted DateTime data
            }
        }
    }
    
    // References:
    // https://stackoverflow.com/questions/14668091/read-registry-binary-and-convert-to-string
    // https://msdn.microsoft.com/en-us/library/system.datetime.frombinary(v=vs.110).aspx
    // https://social.msdn.microsoft.com/Forums/vstudio/en-US/382c06b1-a660-47da-a6e6-a7b27404581a/regbinary-value-from-registry-to-date-format-conversion?forum=csharpgeneral
    // http://nircmd.nirsoft.net/setdefaultsounddevice.html
    // https://stackoverflow.com/questions/3121957/how-can-i-do-a-case-insensitive-string-comparison
