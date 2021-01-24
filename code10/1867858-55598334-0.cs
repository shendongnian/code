    namespace SolarmonAndroidApp.Droid
    {
    [assembly: ExportRenderer(typeof(CustomAndroidPicker), typeof(CustomPickerAndroid))]
     public class CustomPickerAndroid : Xamarin.Forms.Platform.Android.AppCompat.PickerRenderer
     {
        public CustomPickerAndroid(Context context) : base(context)
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Drawable.CustomAndroidEntryDraw);
                Control.Gravity = GravityFlags.CenterHorizontal;
                Control.SetPadding(5, 10, 5, 10);
            }
        }
    }
