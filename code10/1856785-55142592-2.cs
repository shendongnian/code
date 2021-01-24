    public ExcelViewModel()
    {
        SourcePath = @"\\test\\2019";
        CopyCommand= new RelayCommand(CopyExcel);
    }
    private readonly IExcelService fileService;
    public ICommand CopyCommand{ get; private set; }
    
    public ExcelViewModel(IExcelService fileService) : this()
    {
        this.fileService = fileService;   
    }
