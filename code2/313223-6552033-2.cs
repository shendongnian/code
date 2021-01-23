    [Import(typeof(IBar))]
    public ExportFactory<IBar> BarFactory { get; set; }
    
    public void DoSomethingWithBar()
    {
      using (ExportWrapper<IBar> wrapper = BarFactory.CreateExport())
      {
        IBar value = wrapper;
        // Do something with IBar;
        // IBar and NonShared imports will be disposed of after this call finishes.
      }
    }
