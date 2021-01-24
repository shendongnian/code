public interface IBeepWork
{
    void Start();
}
In your Android project:
[assembly: Dependency(typeof(BeepWorkAndroid))]
public class BeepWorkAndroid : IBeepWork
{
    public void Start()
    {
        // Android-specific implementation
    }
}
You can do the same for the iOS project:
[assembly: Dependency(typeof(BeepWorkiOS))]
public class BeepWorkiOS : IBeepWork
{
    public void Start()
    {
        // iOS-specific implementation
    }
}
Then in your code-behind you can resolve the platform-specific instance by calling `DependencyService.Get`:
private async void BtnStart_Clicked(object sender, EventArgs e)
{
    DependencyService.Get<IBeepWork>().Start();
}
