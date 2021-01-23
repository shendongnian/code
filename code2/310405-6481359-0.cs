    public class B : IB
    {
      public int EventsRegistered;
      public event EventHandler Junk
      {
         add
         {
            this.EventsRegistered++;
         }
         remove
         {
            this.EventsRegistered--;
         }
      }
    }
