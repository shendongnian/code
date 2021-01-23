    System.Reflection.Assembly theAsm = Assembly.LoadFrom("My.dll");
    // Get a stream to the embedded resource
    System.IO.Stream stream = theAsm.GetManifestResourceStream(@"picture.png");
    // Here is the most important part:
    System.Windows.Media.Imaging.BitmapImage bmi = new BitmapImage();
    bmi.BeginInit();
    bmi.StreamSource = stream;
    bmi.EndInit();
