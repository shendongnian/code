    public partial class MyEntity : IHaveTimeStamp
    { 
        IHaveTimeStamp.TimeStamp
        { 
            get { return this.TimeStamp; } 
            set { this.TimeStamp = value; } 
        }
    }
