    private List<Whatever> _controls = new List<Whatever>();
    private void InitControlList()
    {
        _controls.Add( someControl );
        _controls.Add( someOtherControl );
        // and so on.  Now just iterate through the list 
        // when you need to update or access the controls.
    }
