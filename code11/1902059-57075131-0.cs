    private string onGuiButtonLabel;
    
    public Button turkishButton;
    public Button englishButton;
    public Button latinButton;
    
    private void Awake()
    {
        turkishButton.onClick.AddListener(()=>{onGuiButtonLabel = "Turkish";})
        englishButton.onClick.AddListener(()=>{onGuiButtonLabel = "English";})
        latinButton.onClick.AddListener(()=>{onGuiButtonLabel = "Latin";})
    }
