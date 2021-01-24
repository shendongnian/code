 c#
public class GenericFactory
    {
        // Assistance with Setter Accessibility: https://stackoverflow.com/questions/3762456/how-to-check-if-property-setter-is-public
        public static T CopyProperties<T>(T newObject, T oldObject, bool ignoreDefaults = true,
            bool skipSelectedProperties = true, params string[] skippedProperties) where T : class
        {
            var type = typeof(T);
            var properties = type.GetProperties();
            foreach (var property in properties)
            {
                if (ignoreDefaults && property.GetValue(oldObject) == default)
                    continue;
                if (skipSelectedProperties && skippedProperties.Contains(property.Name))
                    continue;
                if (!property.CanWrite)
                    continue;
                
                property.SetValue(newObject, property.GetValue(oldObject));
            }
            return newObject;
        }
    }
 c#
private void RecreateScannerView()
        {
            if (Config.DebugMode) Logging.Log(LogType.Debug, $"{nam1eof(RecreateScannerView)} method called");
            ScannerStack.Children.Remove(ScannerView);
            if (Config.DebugMode)
                Logging.Log(LogType.Debug,
                    $"Coping properties from existing {nameof(ZXingScannerView)} into a new {nameof(ZXingScannerView)}");
            ScannerView = GenericFactory.CopyProperties(new ZXingScannerView() {IsScanning = false}, ScannerView,
                skippedProperties: new List<string>() {nameof(ScannerView.IsScanning)}.ToArray());
            ScannerView.OnScanResult += ScannerView_OnScanResult;
            ScannerStack.Children.Add(ScannerView);
        }
c#
private void EnableScan(MobileBarcodeScanningOptions imputedOptions = null)
        {
            if (Config.DebugMode) Logging.Log(LogType.Debug, $"{nameof(EnableScan)} Method is run in Thread named => {Thread.CurrentThread.Name}");
            var chosenOptions = imputedOptions ?? (Config.UseCustomOptions ? Config.CustomOptions : Config.DefaultOptions);
            if (Config.DebugMode)
                Logging.Log(LogType.Information,
                    $"Chose this option for Scanning => {(imputedOptions != null ? nameof(imputedOptions) : (Config.UseCustomOptions ? nameof(Config.CustomOptions) : nameof(Config.DefaultOptions)))}");
            ScannerView.Options = chosenOptions;
            RecreateScannerView();
            Logging.Log(LogType.Information, $"Starting the Scanning...");
            ScannerView.IsScanning = true;
            ScannerView.IsAnalyzing = true;
            ScannerView.IsVisible = true;
            
            if (Config.DebugMode)
                Logging.Log(LogType.Debug,
                    $"{nameof(EnableScan)} Called and Finished; ScannerView.IsAnalyzing => {ScannerView.IsAnalyzing}; ScannerView.IsVisible => {ScannerView.IsVisible}");
        }
My method to flip the value of UseFrontCameraIfAvailable is the one shown in the question above.
Hope to this ends up helping others who might stumble upon a likewise issue.
