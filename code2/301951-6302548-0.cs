Are you using GetInstances?
System.Management.ManagementClass ManagementClass1 = new System.Management.ManagementClass("Win32_Processor");
System.Management.ManagementObjectCollection ManagementObjectCollection1 = ManagementClass1.GetInstances();
foreach (System.Management.ManagementObject managementobject in ManagementObjectCollection1) {
    Console.Out.WriteLine(managementobject.Properties["Name"].Value);
}
Console.In.ReadLine();
