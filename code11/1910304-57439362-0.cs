<TextBlock Text="{x:Bind local:AppSettings.Instance.MySetting, Mode=OneWay}" />
public class AppSettings
{
    private AppSettings()
    {
    }
    public static AppSettings Instance { get; } = new AppSettings();
    public string MySetting => "My setting";
}
