      public partial class Form1 : Form
      {
        public Form1()
        {
          InitializeComponent();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
          for (int i = 0; i < 1000; i++)
          {
            var webRequest = WebRequest.Create(textBox1.Text);
            webRequest.GetReponseAsync().ContinueWith(t =>
            {
              if (t.Exception == null)
              {
                using (var sr = new StreamReader(t.Result.GetResponseStream()))
                {
                  string str = sr.ReadToEnd();
                }
              }
              else
                System.Diagnostics.Debug.WriteLine(t.Exception.InnerException.Message);
            });
          }
        }
      }
    
      public static class WebRequestExtensions
      {
        public static Task<WebResponse> GetReponseAsync(this WebRequest request)
        {
          return Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
        }
      }
