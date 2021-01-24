 c#
sealed class MyDisk // TODO: rename me
{
    public string Key {get;set;}
    public string Name {get;set;}
    public string RegionName {get;set;}
    public int SizeGB {get;set;}
    // etc, but *only* the information you actually want, and *only* using
    // primitive types or types you control
}
...
var disks = (from disk in azure.Disks.List();
             select new MyDisk {
                 Key = disk.Key,
                 Name= disk.Name,
                 RegionName = disk.RegionName,
                 SizeGB  = disk.SizeInGB,
                 // etc
             }).ToList();
And store `disks`, which we *know* doesn't have a circular reference, because *we control it*.
