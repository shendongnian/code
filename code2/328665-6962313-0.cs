    public partial class Order
    {
        partial void Status_Changed()
        {
          if (status == Status.Confirmed)
          {
             // Write code to send email
          }
        }
    }
