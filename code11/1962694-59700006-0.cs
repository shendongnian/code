C#
handling = true;
await LoadTemplateList();
handling = false;
However, it will still return early, because the code is doing some funky private `EventHandler` stuff. If you just remove all that excess code and move the asynchronous code into `LoadTemplateList`, it will work fine:
C#
public class TemplateListViewModel
{
    public double WidthHeight { get; set; }
    public ICommand LoadTemplates => new Command(MyHandler);
    public int CurrentTemplateCountReceived;
    public bool HitBottomOfList = false;
    public ObservableCollection<TemplateSource> sourceList { get; set; }
    public TemplateListViewModel()
    {
        CurrentTemplateCountReceived = 0;
        sourceList = new ObservableCollection<TemplateSource>();
        var mainDisplayInfo = DeviceDisplay.MainDisplayInfo;
        var width = mainDisplayInfo.Width;
        var density = mainDisplayInfo.Density;
        var ScaledWidth = width / density;
        WidthHeight = (ScaledWidth / 2);
        MyHandler();
    }
    private async Task LoadTemplateList()
    {
        if (HitBottomOfList == false)
        {
            List<Template> templateList = await App.RestService.GetTemplates(App.User, CurrentTemplateCountReceived);
            if (templateList != null)
            {
                foreach (var template in templateList)
                {
                    ImageSource source = ImageSource.FromUri(new Uri("mysite.org/myapp/" + template.FileName));
                    TemplateSource templateSource = new TemplateSource { Id = template.Id, Source = source, WidthHeight = WidthHeight, FileName = template.FileName };
                    sourceList.Add(templateSource);
                }
                CurrentTemplateCountReceived = sourceList.Count;
            }
            else
            {
                HitBottomOfList = true;
            }
        }
    }
    bool handling = false;
    public async void MyHandler()
    {
        // already handling an event, ignore the new one
        if (handling) return;
        handling = true;
        await LoadTemplateList();
        handling = false;
    }
}
