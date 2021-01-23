    public class SerialNumberComparer : IEqualityComparer<DataRow>
    {
      public bool Equals(Datarow d1, DataRow d2)
      {
        return d1.Field<string>("SerialNumber") == d2.Field<string>("SerialNumber");
      }
    }
