public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
{
    internal static MainActivity Instance { get; private set; }
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Instance = this;
        ...
    }
}
custom_class.cs
Context context = MainActivity.Instance;
ImageView image = FindViewById<ImageView>(Resource.Id.image);
AssetManager assets = context.Assets;
Stream stream = assets.Open("code.png");
image.SetImageBitmap(BitmapFactory.DecodeStream(stream));
