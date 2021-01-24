    [CascadingParameter]
    public AlertMessageGroup ContainerParent { get; set; }
    
        
    protected override void OnInitialized()
    {
        ContainerParent.AddChild(this);
    }
