    public CancellationTokenSource CancellationTokenSource { get; set; }  
    
    private bool isBusy;
    public bool IsBusy
    { 
      get => this.isBusy;
      set
      {
        this.isBusy = value; 
        OnPropertyChanged();
      }  
    }
    public ICommand LoadChecklistTemplateCommand { get; set; }
    public ICommand CancelDownloadCommand => new DelegateCommand(CancelDownload, () => true);
    
    public CheckListDetailViewModel(IAuditInspectionDataService auditInspectionDataService)
    {
      this.CancellationTokenSource = new CancellationTokenSource();
    
      _auditInspectionDataService = auditInspectionDataService;
      LoadChecklistTemplateCommand = new DelegateCommand(OnLoadTemplate, CanLoadTemplate).ObservesProperty(() => ChecklistItems.Count);
    }
    // Cancel Task instance
    public void CancelDownload()
    {
      this.CancellationTokenSource.Cancel();
    }
    	
    private async Task OnLoadTemplateAsync()
    {
      if (this.IsBusy)
      {
        return;
      }
 
      CancellationToken cancellationToken = this.CancellationTokenSource.Token;
      this.IsBusy = true;
    
      try
      {
        var items = await Task.Run(() =>
        {
          cancellationToken.ThrowIfCancellationRequested();
          return this._auditInspectionDataService.GetCheckList(cancellationToken, InspectionType.InspectionTypeId);
        }, cancellationToken);
    
        this.ChecklistItems = new ObservableCollection<ChecklistItem>(items);
      }
      catch (OperationCanceledException) 
      {
        // CancellationTokenSource can only be used once. Therefore dispose and create new instance
        this.CancellationTokenSource.Dispose();
        this.CancellationTokenSource = new CancellationTokenSource();
        this.ChecklistItems = new ObservableCollection<ChecklistItem>();
      }
    
      this.IsBusy = false;
    }
