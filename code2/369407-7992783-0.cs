    public class Job : IAppointment
    {    
        new public DateTime End
        {
            get
            {
                //get the value directly from the base class
                return base.End;
            }
            set
            {
                //display your messagebox here
                //then pass the value to the base class
                base.End = value;
            }
        }
    }
