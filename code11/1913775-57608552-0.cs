    [JsonIgnore]
    public TBar Data { get; private set; }
    [JsonProperty(PropertyName = nameof(Data))]
    private TBar PrivateData
    {
        get => Data;
        set => Data = value;
    }
