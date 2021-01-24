cs
private async void OnFileOpenOriginGame(string param)
{
    OpenFileDialog dlg = new OpenFileDialog();
    dlg.DefaultExt = ".txt";
    dlg.Filter = "텍스트 파일 (*.txt)|*txt";
    ObservableCollection<List<int>> bb = new ObservableCollection<List<int>>();
    // when Open Dlg
    if (dlg.ShowDialog() == true)
    {
        if (param.Equals("Origin"))
        {
            BJobOnWorkOriginBtn = true;
            OriginGames = new ObservableCollection<List<int>>();
        }
        else if ( param.Equals("Erase"))
        {
            BJobOnWorkExceptBtn = true;
            ExceptGames = new ObservableCollection<List<int>>();
        }
        DispatcherTimer dt= new DispatcherTimer();
        dt.Interval = new TimeSpan(0, 0, 0, 0, 500);
        dt.Tick += (s, e) =>
        {
            App.Current.Dispatcher.BeginInvoke((Action)(() =>
            {
                if (param.Equals("Origin")) OriginGamesCnt = bb.Count;
                else ExceptGamesCnt = bb.Count;
            }), DispatcherPriority.Background);
        };
        dt.Start();
        await Task.Run(async () =>
        {
            using (StreamReader sr = new StreamReader(dlg.FileName))
            {
                while (!sr.EndOfStream)
                {
                    string oneLine = await sr.ReadLineAsync();
                    string[] values = oneLine.Split(' ');
                    List<int> temp = new List<int>();
                    for (int i = 0; i < 6; i++)
                    {
                        int valueInt = -1;
                        bool safe = int.TryParse(values[i], out valueInt);
                        temp.Add(valueInt);
                    }
                    bb.Add(temp);
                }
            }
        });
        dt.Stop();
        if (param.Equals("Origin")) BJobOnWorkOriginBtn = false;
        else BJobOnWorkExceptBtn = false;
        if (param.Equals("Origin"))
        {
            OriginGames = bb;
            OriginGamesCnt = bb.Count;
        }
        else
        {
            ExceptGames = bb;
            ExceptGamesCnt = bb.Count;
        }
    }
}
  [1]: https://i.stack.imgur.com/GNBLR.gif
