    // Dialog View Model
    private MyReusableControlViewModel myReuseableControl;
    public MyReusableControlViewModel MyReuseableControl
    { 
       get { return this.myReuseableControl; }
       set { this.myReuseableControl = value;  NotifyOfPropertyChanged(...); }
    }
 
    // Dialog View Model Constructor
    public DialogViewModel()
    {
      this.MyReuseableControl = new MyReusableControlViewModel();
    }
    // Dialog View
    <DockPanel>
      ...
      <ContentControl x:Name="MyReusableControl" />
    </DockPanel>
