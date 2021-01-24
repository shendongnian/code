    public interface IFrameNoData : IFrame { … }
    public interface IFrame<T> : IFrame { … }
    public abstract class FrameNoData : IFrameNoData { … }
    public abstract class ModalNoData : FrameNoData {...}
    … other abstract classes remain the same …
    public class MyModalNoData : MyModal { … }
