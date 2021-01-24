public void OpenPdfFile(string filename)
{
  var f = new Java.IO.File(filename);
  if (f.Exists())
  {
    System.Diagnostics.Debug.WriteLine("File exists!");
    try
    {
      var openFileIntent = new Intent(Intent.ActionView);
      openFileIntent.SetDataAndType(Android.Net.Uri.FromFile(f), "application/pdf");
      openFileIntent.SetFlags(ActivityFlags.NoHistory);
      StartActivity(Intent.CreateChooser(openFileIntent, "Open pdf file"));
    }
    catch (ActivityNotFoundException)
    {
      //handle when no available apps
    }
  }
}
I haven't tested your work, but the first thing would be to see if you added this to the Manifest file 
android:authorities="com.{package}.{name}.fileprovider"
since your code says `Application.Context.PackageName + ".fileprovider"`
