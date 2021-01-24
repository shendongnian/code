[assembly: Dependency(typeof(OpenPdfFile))]
namespace xxx.iOS
{
    public class OpenPdfFile : IGetRootViewController
    {
        
        public void GetRootViewController()
        {
            string path  = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string filePath = Path.Combine(path,filename);
            //Create a file and write the stream into it.
            FileStream fileStream = File.Open(filePath, FileMode.Create);
            stream.Position = 0;
            stream.CopyTo(fileStream);
            fileStream.Flush();
            fileStream.Close();
            var previewController = new QLPreviewController();
            previewController.DataSource = new QuickLookSource("file://"+filePath);
            UIViewController currentController =
    UIApplication.SharedApplication.KeyWindow.RootViewController;
            while (currentController.PresentedViewController != null)
                currentController = currentController.PresentedViewController;
            currentController.PresentViewController(previewController,true,null);
        }
       
        
    }
    public class QuickLookSource : QLPreviewControllerDataSource
    {
        string filePath;
        public QuickLookSource(string path)
        {
            filePath = path;
        }
        public override nint PreviewItemCount(QLPreviewController controller)
        {
            return 1;
        }
        public override IQLPreviewItem GetPreviewItem(QLPreviewController controller, nint index)
        {
            return new PreviewItem(filePath);
        }
    }
    public class PreviewItem : QLPreviewItem
    {
        NSUrl fileUrl;
        public override NSUrl ItemUrl => fileUrl;
        public override string ItemTitle => fileUrl.LastPathComponent;
        public PreviewItem(string url)
        {
            fileUrl = new NSUrl(url,true);
        }
    }
}
**Note**: Check the filepath of your pdf if it is right.
