using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Ultra_Script.MessageBoxes
{
    public class MsgBoxes
    {
        #region MsgBox k výběru základního SW (stažení z netu nebo Synology)
        public static void SynoInternet()
        {
            Application.EnableVisualStyles();
            Form SynoInternet = new Form();  
            Button Synology = new Button()
            {
                Left = 80,
                Width = 90,
                Height = 30,
                Top = 75,
                Text = "Synology"
            };
            Button Internet = new Button()
            {
                Left = 190,
                Width = 90,
                Height = 30,
                Top = 75,
                Text = "Internet"
            };
            Label SynoInternetLabel = new Label()
            {
                Left = 60,
                Width = 350,
                Height = 25,
                Top = 30,
                Text = "Chceš SW stáhnout z internetu nebo HD Synology?"
            };
            Label fasterLabel = new Label()
            {
                Left = 80,
                Width = 60,
                Height = 20,
                Top = 110,
                Text = "(Rychlejší)"
            };
            SynoInternet.Width = 380;
            SynoInternet.Height = 170;
            SynoInternet.Controls.Add(fasterLabel);
            SynoInternet.Controls.Add(SynoInternetLabel);
            SynoInternet.Controls.Add(Synology);
            SynoInternet.Controls.Add(Internet);
            Synology.Click += (sender, args) =>
            {
                SynoInternet.Dispose();
                Installation_Functions.InstallBasicSW();
            };
            Internet.Click += (sender, args) =>
            {
                MessageBox.Show("You clicked Internet");
            };
            SynoInternet.ShowDialog();
        }
        #endregion
    }
}
InstallFunctions class just call this filedownloader:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Threading;
namespace Ultra_Script
{
    class FileDownloader
    {
        private readonly string _url;
        private readonly string _fullPathWheretoSave;
        private bool _result = false;
        private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(0);
        public FileDownloader(string url, string fullPathWheretoSave)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentNullException("url");
            if (string.IsNullOrEmpty(fullPathWheretoSave)) throw new ArgumentNullException("fullPathWhereToSave");
            this._url = url;
            this._fullPathWheretoSave = fullPathWheretoSave;
        }
        public bool StartDownload(int timeout)
        {
            try
            {
                System.IO.Directory.CreateDirectory(Path.GetDirectoryName(_fullPathWheretoSave));
                if (File.Exists(_fullPathWheretoSave))
                {
                    File.Delete(_fullPathWheretoSave);
                }
                using (WebClient client = new WebClient())
                {
                    var ur = new Uri(_url);
                    //client.Credentials = new NetworkCredential("username", "password");
                    client.DownloadProgressChanged += WebClientDownloadProgressChanged;
                    client.DownloadFileCompleted += WebClientDownloadCompleted;
                    Console.WriteLine(@"Stahuji potrebne soubory:");
                    client.DownloadFileAsync(ur, _fullPathWheretoSave);
                    _semaphore.Wait(timeout);
                    return _result && File.Exists(_fullPathWheretoSave);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Cant download file");
                Console.Write(e);
                return false;
            }
            finally
            {
                this._semaphore.Dispose();
            }
        }
        private void WebClientDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Console.Write($"/r --> {e.ProgressPercentage}%");  
        }
        private void WebClientDownloadCompleted(object sender, AsyncCompletedEventArgs args)
        {
            _result = !args.Cancelled;
            if (!_result)
            {
                Console.Write(args.Error.ToString());
            }
            Console.WriteLine(Environment.NewLine + "Download Finished!");
            _semaphore.Release();
        }
        public static bool DownloadFile(string url, string fullPathWhereToSave, int timeoutInMilliSec)
        {
            return new FileDownloader(url, fullPathWhereToSave).StartDownload(timeoutInMilliSec);
        }
    }
}
What is doing its closing the form and then run back function in console. But it only says: "Start downloading" and after timeout it goes: Exception thrown: 'System.ComponentModel.Win32Exception' in System.dll in visual studio
When i run step by step debugging i think it stopped on that Semaphore method, but its not working even if i delete this method in filedownloader.
When i call function from console its working normally problem is only when i call it through that button in messagebox.
