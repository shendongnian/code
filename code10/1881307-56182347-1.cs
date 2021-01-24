powershell
[System.Management.ManagementDateTimeConverter]::ToDateTime('20190516060354.000000+000')       
Wednesday, May 15, 2019 11:03:54 PM
or C#
csharp
using System;
using System.Management;
System.DateTime dt = ManagementDateTimeConverter.ToDateTime("20190516060354.000000+000");
Console.WriteLine(dt);
