    public class CustomComparer : IComparer<Status>
    {
         public int Compare(Status statusA, Status statusB)
         {
           if (statusA.StatusName == "Cancelled" && statusB.StatusName == "Cancelled")
           {
              return 0; // equals
           } 
           else if (statusA.StatusName == "Cancelled" && statusB.StatusName != "Cancelled")
           {
              return 1; // A > B
           }
           ....
         }
    }
