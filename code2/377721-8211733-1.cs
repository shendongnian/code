    public partial class News : PhoneApplicationPage
        {
            public News()
            {
    
                UriBuilder fullUri = new UriBuilder("http://news.google.co.in/news");
                fullUri.Query = "hl=en&gl=in&q=mumbai+marathon&um=1&ie=UTF-8&output=rss";
                HttpWebRequest forecastRequest = (HttpWebRequest)WebRequest.Create(fullUri.Uri);
    
                ForecastUpdateState forecastState = new ForecastUpdateState();
                forecastState.AsyncRequest = forecastRequest;
    
                forecastRequest.BeginGetResponse(new AsyncCallback(HandleForecastResponse), forecastState);
    
                //  wbt.URL = "http://www.google.com";
                //wbt.Show();
    
                InitializeComponent();
            }
            private void HandleForecastResponse(IAsyncResult asyncResult)
            {
                ForecastUpdateState forecastState = (ForecastUpdateState)asyncResult.AsyncState;
                HttpWebRequest forecastRequest = (HttpWebRequest)forecastState.AsyncRequest;
    
                forecastState.AsyncResponse = (HttpWebResponse)forecastRequest.EndGetResponse(asyncResult);
    
                Stream streamResult;
                // get the stream containing the response from the async call
                streamResult = forecastState.AsyncResponse.GetResponseStream();
                // load the XML
                XElement xmlNews = XElement.Load(streamResult);
                XElement xmlCurrent = xmlNews.Descendants("channel").First();
                XElement x1 = xmlCurrent.Descendants("item").First();
                string title = (string)x1.Element("title");
    
    
                IEnumerable<XElement> xmlIEnumerableNews = xmlCurrent.Descendants("item");
    
                IEnumerable<NewsDetails> objIEnumerableNews = from element in xmlIEnumerableNews
                                                              select new NewsDetails
                                                              {
                                                                  title = (string)(element.Element("title")),
                                                                  link = (string)(element.Element("guid")),
                                                                  date = (string)(element.Element("pubDate"))
                                                              };
    
    
                List<NewsDetails> objListNews = new List<NewsDetails>();
                int count = objListNews.Count;
                foreach (NewsDetails news in objIEnumerableNews)
                {
                    news.title = news.title + " " + news.date;
                    int pos = news.link.IndexOf('=');
                    news.link = news.link.Substring(pos + 1, news.link.Length - pos - 1);
                    objListNews.Add(news);
                }
               
                int t = objListNews.Count();
                Deployment.Current.Dispatcher.BeginInvoke(() =>
                {
                    listBoxNews.ItemsSource = objListNews;
                });
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                NewsDetails news = (sender as Button).DataContext as NewsDetails;
                WebBrowserTask wbt = new WebBrowserTask();
                wbt.URL = news.link;
                wbt.Show();
    
            }
    
            private void FAQs_Click(object sender, EventArgs e)
            {
                NavigationService.Navigate(new Uri("/Info/FAQs/Questions.xaml", UriKind.Relative));
    
            }
    
            private void Weather_Click(object sender, EventArgs e)
            {
                NavigationService.Navigate(new Uri("/Info/Weather.xaml", UriKind.Relative));
    
            }
    
            private void About_Click(object sender, EventArgs e)
            {
                NavigationService.Navigate(new Uri("/Info/About.xaml", UriKind.Relative));
    
            }
    
        }
        public class NewsDetails
        {
            public string title { get; set; }
            public string link { get; set; }
            public string date { get; set; }
            //public String title, link, description;
        }
