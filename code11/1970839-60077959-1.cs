    <Button Command="{Binding Path=PressMe}" />
    private ICommand _pressMe;
    public ICommand PressMe
    {
        get
        {
            if (_pressMe== null)
            {
                _pressMe= new RelayCommand(
                    param => this.PressMeObject(), 
                    param => this.CanPress()
                );
            }
            return _pressMe;
        }
    }
    
    private void PressMeObject()
    {
        // Press me logic hier
    }
    private bool CanPress()
    {
        // Verify command can be executed here
    }
