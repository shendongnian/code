namespace xxx
{
    public interface IPhotoPickerService
    {
        Task<Dictionary<string,Stream>> GetImageStreamAsync();
    }
}
###in iOS
[assembly: Dependency (typeof (PhotoPickerService))]
namespace xxx.iOS
{
    public class PhotoPickerService : IPhotoPickerService
    {
        TaskCompletionSource<Dictionary<string, Stream>> taskCompletionSource;
        UIImagePickerController imagePicker;
        Task<Dictionary<string, Stream>> IPhotoPickerService.GetImageStreamAsync()
        {
            // Create and define UIImagePickerController
            imagePicker = new UIImagePickerController
            {
                SourceType = UIImagePickerControllerSourceType.PhotoLibrary,
                MediaTypes = UIImagePickerController.AvailableMediaTypes(UIImagePickerControllerSourceType.PhotoLibrary)
            };
            // Set event handlers
            imagePicker.FinishedPickingMedia += OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled += OnImagePickerCancelled;
            // Present UIImagePickerController;
            UIWindow window = UIApplication.SharedApplication.KeyWindow;
            var viewController = window.RootViewController;
            viewController.PresentModalViewController(imagePicker, true);
            // Return Task object
            taskCompletionSource = new TaskCompletionSource<Dictionary<string, Stream>>();
            return taskCompletionSource.Task;
        }
       
        void OnImagePickerFinishedPickingMedia(object sender, UIImagePickerMediaPickedEventArgs args)
        {
            UIImage image = args.EditedImage ?? args.OriginalImage;
            if (image != null)
            {
                // Convert UIImage to .NET Stream object
                NSData data;
                if (args.ReferenceUrl.PathExtension.Equals("PNG") || args.ReferenceUrl.PathExtension.Equals("png"))
                {
                    data = image.AsPNG();
                }
                else
                {
                    data = image.AsJPEG(1);
                }
                Stream stream = data.AsStream();
                UnregisterEventHandlers();
                Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
                dic.Add(args.ImageUrl.ToString(), stream);
                // Set the Stream as the completion of the Task
                taskCompletionSource.SetResult(dic);
            }
            else
            {
                UnregisterEventHandlers();
                taskCompletionSource.SetResult(null);
            }
            imagePicker.DismissModalViewController(true);
        }
        void OnImagePickerCancelled(object sender, EventArgs args)
        {
            UnregisterEventHandlers();
            taskCompletionSource.SetResult(null);
            imagePicker.DismissModalViewController(true);
        }
        void UnregisterEventHandlers()
        {
            imagePicker.FinishedPickingMedia -= OnImagePickerFinishedPickingMedia;
            imagePicker.Canceled -= OnImagePickerCancelled;
        }
        
    }
}
###in Android
**in MainActivity**
public class MainActivity : FormsAppCompatActivity
{
    ...
    // Field, property, and method for Picture Picker
    public static readonly int PickImageId = 1000;
    public TaskCompletionSource<Dictionary<string,Stream>> PickImageTaskCompletionSource { set; get; }
    protected override void OnActivityResult(int requestCode, Result resultCode, Intent intent)
    {
        base.OnActivityResult(requestCode, resultCode, intent);
        if (requestCode == PickImageId)
        {
            if ((resultCode == Result.Ok) && (intent != null))
            {
                Android.Net.Uri uri = intent.Data;
                Stream stream = ContentResolver.OpenInputStream(uri);
                Dictionary<string, Stream> dic = new Dictionary<string, Stream>();
                dic.Add(uri.ToString(), stream);
                // Set the Stream as the completion of the Task
                PickImageTaskCompletionSource.SetResult(dic);
            }
            else
            {
                PickImageTaskCompletionSource.SetResult(null);
            }
        }
    }
}
[assembly: Dependency(typeof(PhotoPickerService))]
namespace xxx.Droid
{
    public class PhotoPickerService : IPhotoPickerService
    {
        public Task<Dictionary<string,Stream>> GetImageStreamAsync()
        {
            // Define the Intent for getting images
            Intent intent = new Intent();
            intent.SetType("image/*");
            intent.SetAction(Intent.ActionGetContent);
            // Start the picture-picker activity (resumes in MainActivity.cs)
            MainActivity.Instance.StartActivityForResult(
                Intent.CreateChooser(intent, "Select Picture"),
                MainActivity.PickImageId);
            // Save the TaskCompletionSource object as a MainActivity property
            MainActivity.Instance.PickImageTaskCompletionSource = new TaskCompletionSource<Dictionary<string,Stream>>();
            // Return Task object
            return MainActivity.Instance.PickImageTaskCompletionSource.Task;
        }
    }
}
###invoke it
Dictionary<string, Stream> dic = await DependencyService.Get<IPhotoPickerService>().GetImageStreamAsync();
Stream stream;
string path;
foreach ( KeyValuePair<string, Stream> currentImage in dic )
{
   stream = currentImage.Value;
   // save it    
}
