public class MyEntry : Entry
{
}
in xaml
<local:MyEntry Placeholder="Message"
               x:Name="messageTxt"
               HorizontalOptions="FillAndExpand" />
### in Android Project
using xxx;
using xxx.Droid;
using Xamarin.Forms.Platform.Android;
//...
[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace xxx.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        public MyEntryRenderer(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
               // do something you want here . the control is the native elements 
                  EditText in Android
            }
        }
    }
}
  [1]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/app-fundamentals/custom-renderer/
