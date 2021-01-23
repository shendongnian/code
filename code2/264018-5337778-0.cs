    public abstract class PresenterBase<T> where T : PresenterBase<T>
    {
        public static Dictionary<string, MethodInfo> methodsList = 
             new Dictionary<string,MethodInfo>();
    }
    public class DevicePresenter : PresenterBase<DevicePresenter>
    {
    }
    public class HomePresenter : PresenterBase<HomePresenter>
    {
    } 
