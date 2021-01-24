ObservableCollection<Buku> datasource = new ObservableCollection<Buku>();
int offset = 1; // set offset zero to one 
        private void MainGrid_Loaded(object sender, RoutedEventArgs e)
                    {
                        itemGridView.ItemsSource = datasource;
                        Umum(offset); // just change 1 to offset 
                    } 
    public class Buku
        {
            public string Judul { get; set; }
        }
            private async void Umum(int offset)
            {
                urlPath = "mhnkp2.com/school/api-v3/fetch/ktsp2006/kelas/1";
                var httpClient = new HttpClient(new HttpClientHandler());
                var values = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("halaman", offset.ToString()),
                    new KeyValuePair<string, string>("limit", "16"),
                    new KeyValuePair<string, string>("SCH-API-KEY", "SCH_KEnaBiDeplebt")
                };
                var response = await httpClient.PostAsync(urlPath, new FormUrlEncodedContent(values));
                response.EnsureSuccessStatusCode();
                string jsonText = await response.Content.ReadAsStringAsync();
                try
                {
                    double total = groupObject1["total_data"].GetNumber();
                    double pages = groupObject1["total_page"].GetNumber();
                    double page = groupObject1["current_page"].GetNumber();
                    Buku file = new Buku();
                    file.PageNo = Convert.ToInt32(page);
                    file.Pages = Convert.ToInt32(pages);
                    file.Total = Convert.ToInt32(total);
                    JsonArray jsonData1 = jsonObject["data"].GetArray();
                    foreach (JsonValue groupValue1 in jsonData1)
                    {
                        JsonObject groupObject2 = groupValue1.GetObject();
                        string title = groupObject2["judul"].GetString();
                        Buku file1 = new Buku();
                        file1.Judul = title;
                        datasource.Add(file1);
                    }
                    itemGridView.ItemsSource = datasource;
                }
            }
            private void itemGridView_Loaded(object sender, RoutedEventArgs e)
                    {
                        ScrollViewer viewer = GetScrollViewer(this.itemGridView);
                        viewer.ViewChanged += Viewer_ViewChanged;
                    }
                    private void Viewer_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
                    {
                        ScrollViewer view = (ScrollViewer)sender;
                        double progress = view.VerticalOffset / view.ScrollableHeight;
                        //Debug.WriteLine(progress);
                        if (progress > 0.7 && !incall && !endoflist)
                        {
                            incall = true;
                            busyindicator.IsActive = true;
                            Umum(offset++);
                        }
                    }
                    public static ScrollViewer GetScrollViewer(DependencyObject depObj)
                    {
                        if (depObj is ScrollViewer) return depObj as ScrollViewer;
                        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                        {
                            var child = VisualTreeHelper.GetChild(depObj, i);
                            var result = GetScrollViewer(child);
                            if (result != null) return result;
                        }
                        return null;
                    }
