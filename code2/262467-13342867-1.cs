    public RelayCommand ChartCommand
    {
        set
        {
            RelayCommand<string> chartCommand = 
                new RelayCommand<string>(e => ExecuteChartCommand(e));               
        }
    }
    public void ExecuteChartCommand(string vendor)
    {
    }
