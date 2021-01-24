public partial class MainWindow : Window
{
        private ObservableCollection<TableDataClass> tableDataFill; //This line is new
        public MainWindow()
        {
            Initialize Component();
            tableDataFill = new ObservableCollection<TableDataClass>() {}; //This line is new
        }
Then, down where I was trying to fill the table with the list, I changed it from the above to the following:
tableDataFill.add(new TableDataClass ()
{
    HdrDisk =disknum,
    HDRDTG = asciiString,
    TotalDisk = totDiskNum,
    SeqNum = seqNumCount,
    fileSize = fileSizeTemp
}
TableData.ItemsSource = tableDataFill;
It took a fair bit of restructuring my code and moving away from List, but it is working now.
Thanks again to Abin.
