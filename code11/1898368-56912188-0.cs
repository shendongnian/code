    public class ListAttribute : PXStringListAttribute
      {
        public ListAttribute()
          : base(new string[5]{ "A", "H", "P", "I", "T" }, new string[5]
          {
            "Active",
            "On Hold",
            "Hold Payments",
            "Inactive",
            "One-Time"
          })
        {
        }
      }
    }
