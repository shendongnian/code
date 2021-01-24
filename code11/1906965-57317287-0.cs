using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.Devices.PointOfService;
using System.Threading.Tasks;
using Windows.Media.Capture;
using Windows.Devices.Enumeration;
using System.Diagnostics;
using Windows.Storage.Streams;
namespace StackOverflowQrTest
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            if (claimedScanner == null)
            { 
                await StartScannerAsync();
            }
        }
        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            await StopScannerAsync();
        }
        private BarcodeScanner scanner { get; set; }
        private ClaimedBarcodeScanner claimedScanner { get; set; }
        private MediaCapture captureManager { get; set; }
        internal async Task StartScannerAsync()
        {
            capturePreview.Visibility = Visibility.Visible;
            capturePreview.Width = 400; capturePreview.Height = 300;
            scanner = await DeviceHelpers.GetFirstDeviceAsync(BarcodeScanner.GetDeviceSelector(), async (id) => await BarcodeScanner.FromIdAsync(id));
            if (scanner != null)
            {
                claimedScanner = await scanner.ClaimScannerAsync();
                if (claimedScanner != null)
                {
                    claimedScanner.ReleaseDeviceRequested += ClaimedScanner_ReleaseDeviceRequested;
                    claimedScanner.DataReceived += ClaimedScanner_DataReceived;
                    claimedScanner.IsDecodeDataEnabled = true;
                    await claimedScanner.EnableAsync();
                    bool haveAssociatedCamera = !string.IsNullOrEmpty(scanner.VideoDeviceId);
                    if (haveAssociatedCamera)
                    {
                        captureManager = new MediaCapture();
                        captureManager.Failed += CaptureManager_Failed;
                        MediaCaptureInitializationSettings _captureInitSettings = new MediaCaptureInitializationSettings
                        {
                            VideoDeviceId = scanner.VideoDeviceId,
                            SharingMode = MediaCaptureSharingMode.SharedReadOnly, // share
                            StreamingCaptureMode = StreamingCaptureMode.Video     // just video
                        };
                        await captureManager.InitializeAsync(_captureInitSettings);
                        capturePreview.Source = captureManager;
                    }
                    try
                    {
                        UpdateMessage("waiting..." + (!haveAssociatedCamera ? "But scanner not camera type" : ""));
                        if (captureManager != null) await captureManager.StartPreviewAsync();
                        await claimedScanner.StartSoftwareTriggerAsync();
                    }
                    catch (Exception e)
                    {
                        UpdateMessage(e.Message);
                        Debug.WriteLine("EXCEPTION: " + e.Message);
                    }
                }
                else
                {
                    UpdateMessage("Could not claim barcode scanner");
                }
            }
            else
            {
                UpdateMessage("No barcode scanners found");
            }
        }
        private void CaptureManager_Failed(MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs)
        {
            string msg = string.Format("MediaCapture_Failed: (0x{0:X}) {1}", errorEventArgs.Code, errorEventArgs.Message);
            UpdateMessage(msg);
        }
        internal async Task StopScannerAsync()
        {
            if (captureManager != null)
            {
                if (captureManager.CameraStreamState == Windows.Media.Devices.CameraStreamState.Streaming)
                {
                    await captureManager.StopPreviewAsync();
                }
                captureManager.Dispose();
                captureManager = null;
            }
            if (claimedScanner != null)
            {
                claimedScanner.Dispose();
                claimedScanner = null;
            }
            if (scanner != null)
            {
                scanner.Dispose();
                scanner = null;
            }
        }
        private void ClaimedScanner_DataReceived(ClaimedBarcodeScanner sender, BarcodeScannerDataReceivedEventArgs args)
        {
            var scanDataLabelReader = DataReader.FromBuffer(args.Report.ScanDataLabel);
            string barcode = scanDataLabelReader.ReadString(args.Report.ScanDataLabel.Length);
            UpdateMessage(barcode);
        }
        private void ClaimedScanner_ReleaseDeviceRequested(object sender, ClaimedBarcodeScanner e)
        {
            UpdateMessage("Another process is requesting barcode scanner device.");
            e.RetainDevice(); 
        }
        private async void UpdateMessage (string message)
        {
            await LastBarcodeRead.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
            {
                LastBarcodeRead.Text = message;
            });
        }
    }
    public partial class DeviceHelpers
    {
        // We use a DeviceWatcher instead of DeviceInformation.FindAllAsync because
        // the DeviceWatcher will let us see the devices as they are discovered,
        // whereas FindAllAsync returns results only after discovery is complete.
        public static async Task<T> GetFirstDeviceAsync<T>(string selector, Func<string, Task<T>> convertAsync)
            where T : class
        {
            var completionSource = new TaskCompletionSource<T>();
            var pendingTasks = new List<Task>();
            DeviceWatcher watcher = DeviceInformation.CreateWatcher(selector);
            watcher.Added += (DeviceWatcher sender, DeviceInformation device) =>
            {
                Func<string, Task> lambda = async (id) =>
                {
                    T t = await convertAsync(id);
                    if (t != null)
                    {
                        completionSource.TrySetResult(t);
                    }
                };
                pendingTasks.Add(lambda(device.Id));
            };
            watcher.EnumerationCompleted += async (DeviceWatcher sender, object args) =>
            {
                // Wait for completion of all the tasks we created in our "Added" event handler.
                await Task.WhenAll(pendingTasks);
                // This sets the result to "null" if no task was able to produce a device.
                completionSource.TrySetResult(null);
            };
            watcher.Start();
            // Wait for enumeration to complete or for a device to be found.
            T result = await completionSource.Task;
            watcher.Stop();
            return result;
        }
    }
}
Where main xaml is... 
<Page
    x:Class="StackOverflowQrTest.MainPage"
    xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
    xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
    xmlns:local="using:StackOverflowQrTest"
    xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    Background="{ThemeResource ApplicationPageBackgroundThemeBrush}">
    <ScrollViewer>
        <StackPanel>
            <Button Content="Start Preview" HorizontalAlignment="Center" Click="Button_Click"  Margin="5" />
            <CaptureElement x:Name="capturePreview" HorizontalAlignment="Center" Stretch="Uniform" Width="0" Height="0" Margin="10" />
            <Button Content="Stop Preview" HorizontalAlignment="Center" Click="Button_Click_1"  Margin="5" />
            <TextBox Header="LastBarcode" Name="LastBarcodeRead" IsReadOnly="True" HorizontalAlignment="Center" Margin="5" />
        </StackPanel>
    </ScrollViewer>
</Page>
