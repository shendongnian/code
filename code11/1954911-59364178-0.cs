using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
namespace RequestTest
{
    public partial class Form1 : Form
    {
        List<Requester> requesters;
        DateTime start;
        int counter;
        public Form1()
        {
            InitializeComponent();
            requesters = new List<Requester>();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            start = DateTime.Now;
            for (int i = 0; i < 30; i++)
            {
                requesters.Add(new Requester(this, i + 1));
                // only one of the following 3 lines should be uncommented
                //requesters[i].RequestWeb(); // this uses the old WebClient (~ 12 sec)
                //await requesters[i].RequestHttp(); // this takes forever since requests are executed one at a time (~ 86 sec)
                _ = requesters[i].RequestHttp(); // <-- This is the way to go for my app. Dispatch the request and continue executing discarding the result. Callback is called in the same method. (~ 13 sec, consistent with option #1)
            }
        }
        public void SomeoneCompletedDownload(string page)
        {
            var elapsed = DateTime.Now - start;
            counter++;
            textBox1.AppendText($"#{counter}: Page {page} finished after {elapsed.TotalSeconds.ToString("N2")} seconds.\r\n");
        }
    }
    public class Requester
    {
        Form1 caller;
        string page;
        string url;
        public Requester(Form1 _caller, int _page)
        {
            caller = _caller;
            page = _page.ToString();
            url = "https://www.youtube.com/";
        }
        public void RequestWeb()
        {
            var client = new WebClient();
            client.DownloadStringCompleted += DownloadCompleted;
            client.DownloadStringAsync(new Uri(url));
        }
        public async Task RequestHttp()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            caller.SomeoneCompletedDownload(page);
        }
        private void DownloadCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            caller.SomeoneCompletedDownload(page);
        }
    }
}
