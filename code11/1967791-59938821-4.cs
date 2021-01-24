public class Order
{
    public int OrderID { get; set; }
    public int FacilityID { get; set; }
    public string FacilityOrderID { get; set; }
    public string StatusID { get; set; }
    public bool Contract { get; set; }
    public bool PermPlacement { get; set; }
    public string ShiftDate { get; set; }
    public string StartTime { get; set; }
    public string EndTime { get; set; }
    public int Meals { get; set; }
    public string Con_StartDate { get; set; }
    public string Con_EndDate { get; set; }
    public bool Locked { get; set; }
    public string LastModified { get; set; }
    public string CreatedDate { get; set; }
    public string FacilityName { get; set; }
    public int ScheduledRegID { get; set; }
    public string ScheduledRegName { get; set; }
    public string ClassName { get; set; }
    public string ClassDesc { get; set; }
    public string AltClassName { get; set; }
    public string AltClassDesc { get; set; }
    public string CodeName { get; set; }
    public int ShiftNumber { get; set; }
    public int AreaID { get; set; }
    public string AreaName { get; set; }
    public string AreaAddress1 { get; set; }
    public string AreaAddress2 { get; set; }
    public string AreaCity { get; set; }
    public string AreaCounty { get; set; }
    public string AreaState { get; set; }
    public string AreaZip { get; set; }
    public string LockReason { get; set; }
    public string CancelReason { get; set; }
    public string Note { get; set; }
    public bool IsTraveler { get; set; }
    public int Rate { get; set; }
    public string ContractPattern { get; set; }
    public int Con_Guarantee { get; set; }
    public int Con_Weeks { get; set; }
}
public class Data
{
    public List<Order> Orders { get; set; }
}
public class D
{
    public bool success { get; set; }
    public object errorMessage { get; set; }
    public Data data { get; set; }
}
public class RootObject
{
    public D d { get; set; }
}
and you would **deserialize your json** to the `RootObject`, like so.
    var obj = JsonConvert.DeserializeObject<RootObject>(json);
    List<Order> allOrders = obj.d.data.Orders;
Once you have deserialized your json, you can access the Orders and do what you need to do with them.
[Working copy of your code](https://dotnetfiddle.net/XLKy97)
