    public interface IPolicy
    {
        string Description { get; }
        string Reg { get; }
        string Contents { get; }
    }
    public class MotorPolicy : IPolicy
    {
        public string Description
        {
            get { return ...; }
        }
        public string Reg
        {
            get { return ...; }
        }
        public string Contents
        {
            get { return String.Empty; }
        }
    }
    public class HousholdPolicy : IPolicy
    {
        public string Description
        {
            get { return ...; }
        }
        public string Reg
        {
            get { return String.Empty; }
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
