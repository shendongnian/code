    public interface IPolicy
    {
        string Description { get; }
    }
    public interface IHasReg
    {
        string Reg { get; }
    }
    public interface IHasContents
    {
        string Contents { get; }
    }
    public class MotorPolicy : IPolicy, IHasReg
    {
        public string Description
        {
            get { return ...; }
        }
        public string Reg
        {
            get { return ...; }
        }
    }
    public class HouseholdPolicy : IPolicy, IHasContents
    {
        public string Description
        {
            get { return ...; }
        }
        public string Contents
        {
            get { return ...; }
        }
    }
    public class Response
    {
        ...
        private IPolicy             _policy;
        ....
    }
