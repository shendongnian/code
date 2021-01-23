     protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
           components.Dispose();
           // Release managed resources
           Logger.Verbose("Disposing SettingForm");
           mySetting.Dispose();
           testFtp.Dispose();
        }
        base.Dispose(disposing);
     }
