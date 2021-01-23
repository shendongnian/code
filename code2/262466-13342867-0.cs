    Another way to declare relay commands, will help to reduce your code
    public RelayCommand ChartCommand
    {
        set
        {
            RelayCommand<string> chartCommand = new RelayCommand<string>(e => ExecuteChartCommand(e));               
        }
    }
    public void ExecuteChartCommand(string vendor)
    {
    }
