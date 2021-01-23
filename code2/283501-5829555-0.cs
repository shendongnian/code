    public class EducatedAdult : IAdult, IEducated
    {
        public virtual void Age()
        {
            ...
        }
        public virtual void LicenseNo()
        {
            ...
        }
        public virtual void Read()
        {
            ...
        }
        public virtual void Write()
        {
            ...
        }
    }
    public class Carpenter : EducatedAdult
    {
        ....
    }
