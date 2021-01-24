    public ObservableCollection<ReportData> GetQueryData(string date, string ip, string query)
    {
        ObservableCollection<ReportData> result = new ObservableCollection<ReportData>();
        try
        {
            var data = GetRemoteQueryJournal(ip, date, query);
            if (data != null)
            {
                result = GetReporData(data);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.InnerException.StackTrace);
        }
        return result;
    }
