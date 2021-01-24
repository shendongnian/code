public static void SetFileProtection(string filePath)
{
    NSMutableDictionary dict = new NSMutableDictionary ();
    var protection = new NSString("NSFileProtectionCompleteUnlessOpen");
    dict.Add((new NSString("NSFileProtectionKey") as NSObject), (protection as NSObject));
    NSError error;
    NSFileManager.DefaultManager.SetAttributes(dict, filePath, out error);
    if (error != null)
        System.Console.WriteLine("SetFileProtection Error: " + error.Description);
}
You can test the functionality using [iExplorer][2]. You will see that the data won't be accessible unless the device is trusted. Choose the appropriate Protection level with the help of the Data Protection Classes in the official docs:
> (NSFileProtectionComplete): The class key is protected with a key
derived from the user passcode and the device UID. Shortly after the user
locks a device (10 seconds, if the Require Password setting is Immediately),
the decrypted class key is discarded, rendering all data in this class
inaccessible until the user enters the passcode again or unlocks the device
using Touch ID or Face ID.
  [1]: https://www.apple.com/business/docs/site/iOS_Security_Guide.pdf
  [2]: https://macroplant.com/iexplorer
