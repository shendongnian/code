    <sdk:AutoCompleteBox Width="169" x:Name="txtSearchBox" Text="{Binding TypedText, Mode=TwoWay}" />
    private string _typedText;
    public string TypedText
    {
        get { return _typedText; }
        set
        {
            _typedText = value.ToUpper();
            NotifyPropertyChanged("TypedText");
            // Also maintain the cursor position here
        }
    }
     
