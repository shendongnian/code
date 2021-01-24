    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
             static void Main(string[] args)
             {
                 DataTable dt = new DataTable();
                 dt.Columns.Add("NotificationGroupId", typeof(int));
                 dt.Columns.Add("DeliveryTypeId", typeof(int));
                 dt.Rows.Add(new object[] { 1, 1 });
                 dt.Rows.Add(new object[] { 3, 2 });
                 dt.Rows.Add(new object[] { 4, 1 });
                 dt.Rows.Add(new object[] { 4, 2 });
                 dt.Rows.Add(new object[] { 5, 2 });
                 dt.Rows.Add(new object[] { 1, 1 });
                 dt.Rows.Add(new object[] { 3, 2 });
                 dt.Rows.Add(new object[] { 4, 1 });
                 dt.Rows.Add(new object[] { 4, 2 });
                 dt.Rows.Add(new object[] { 5, 2 });
                 List <CompareID> ids = dt.AsEnumerable()
                     .Select(x => new CompareID() { NotificationGroupId = x.Field<int>("NotificationGroupId"), DeliveryTypeId = x.Field<int>("DeliveryTypeId") })
                     .Distinct()
                     .ToList();
     
             }
        }
        public class CompareID : IEquatable <CompareID>
        {
            public int NotificationGroupId { get; set; }
            public int DeliveryTypeId { get; set; }
            public bool Equals(CompareID other)
            {
                if ((this.NotificationGroupId == other.NotificationGroupId) && (this.DeliveryTypeId == other.DeliveryTypeId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            public override bool Equals(Object obj)
            {
                return this.Equals((CompareID)obj);
            }
            public override int GetHashCode()
            {
                return (NotificationGroupId.ToString() + "^" + DeliveryTypeId.ToString()).GetHashCode();
            }
        }
       
    }
