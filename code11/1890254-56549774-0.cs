c#
//  Your Form class is probably called something else. 
public Form1()
{
    InitializeComponent();
    //  Since backgroundWorker was created in the form designer, it will have been 
    //  initialized in InitializeComponent(). Therefore, this has to happen after 
    //  InitializeComponent() is called. 
    InitializeBackgroundWorkerHandlers();
}
private void InitializeBackgroundWorkerHandlers()
{
    backgroundWorker.DoWork += (s, e) =>
    {
        test.RunTests();
    };
    backgroundWorker.RunWorkerCompleted += (s, e) =>
    {
        ShowCompleteMessage();
    };
}
//  this is called from an onclick method
private void RunAlgorithmTests()
{
    backgroundWorker.RunWorkerAsync();
}
