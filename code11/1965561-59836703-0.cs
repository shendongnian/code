Dictionary<string, ObservableCollection<object>> dataDic = new Dictionary<string, ObservableCollection<object>>();
ObservableCollection<ListViewThumbnailViewModel> result = new ObservableCollection<ListViewThumbnailViewModel>();
foreach (KeyValuePair<string, ObservableCollection<object>> pair in dataDic)
{
    DateTime _date = DateTime.ParseExact(pair.Key, PRIVATE_DATE_FORMAT, CultureInfo.InvariantCulture);
    for (int i = 0; i <= dataDic.FirstOrDefault().Value.Count - 1 && i <= result.Count ; i += 10)
    {
        result.Insert(i, new ListViewThumbnailViewModel()
        {
            DateItem = _date,
            ListThumbnail = pair.Value
        });
        result.Skip(i).Take(10).ToList(); // use the return value here
        Thread.Sleep(100);
    }
}
Also be carreful about `firstOrDefault` that first or default can return nothing and it's also a point that can fail.
