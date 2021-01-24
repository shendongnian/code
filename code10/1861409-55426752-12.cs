    public interface IComponent
    {
         void OnGo1Screen(object obj);
         void OnGo2Screen(object obj);
    }
    public class MainWindowViewModel : BaseViewModel, IComponent
