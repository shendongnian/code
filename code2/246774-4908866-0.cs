    private delegate void delegateUpdateProgressBar(int iValue);
    private delegateUpdateProgressBar updateProgressBar;
    public Form1()
    {
       InitializeComponent();
       updateProgressBar = new delegateUpdateProgressBar(UpdateProgressBar);
    }
    
    private void UpdateProgressBar(int iValue)
    {
       ProgressBar1.Value = iValue;
    }
    
    private void Test()
    {
       // just call Invoke in any thread(s)
       // new objext[]{45} -> ProgressBar.Value = 45;
       Invoke(updateProgressBar, new object[] {45});
    }
