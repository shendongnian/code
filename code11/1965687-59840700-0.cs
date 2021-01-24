    public class BaseDto
    {
        public virtual string Name { get; set; }
    }
    public class DerivedDto : BaseDto
    {
        public override string Name { get; set; }
    }
