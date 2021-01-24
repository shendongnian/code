public class DiskInfo
{
    private int index = 0;
    private string model = String.Empty;
    private unsigned long size = 0;
    public int getIndex() { return index; }
    public string getModel() { return model; }
    public unsigned long getSize() { return size; }
    public DiskInfo(int index, string model, unsigned long size)
    {
        this.index = index;
        this.model = model;
        this.size = size;
    }
    public string ToString()
    {
        return string.Format("{0, -15} {1,-35} {2, -20}", index, model, size);
    }
}
// ...
List<DiskInfo> lst = new List<DiskInfo>();
foreach (ManagementObject disk in objectSearcher.Get() )
{
    lst.Add(new DiskInfo(
        disk.GetPropertyValue("Index"),
        disk.GetPropertyValue("Model"),
        diskSize
    ));
}
Then you can use simple linq to sort.
lst = lst.OrderBy(x => x.getIndex());
On top of that you get ide support and compiler errors.
