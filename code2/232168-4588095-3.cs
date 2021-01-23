    public interface IEnableable {
        bool Enable { get; set; }
    }
    public interface IResettable {
        void Reset();
    }
    public interface IEnableableAndResettable : IEnableable, IResettable { }
