    public Collection<Control> findControlsWithAttributes(Control startingControl)
    {
        Collection<Control> toReturn = new Collection<Control>();
        foreach (Control curControl in startingControl.controls)
        {
            if (DO COMPARISON HERE WITH CURCONTROL) toReturn.add(curControl);
            if (curControl.Count() > 0) findControlsWithAttributes(curControl, toReturn);
        }
        return toReturn;
    }
    
    private void findControlsWithAttributes(Control startingControl, Collection<Control> inputCollection)
    {
        foreach (Control curControl in startingControl.controls)
        {
            if (DO COMPARISON HERE WITH CURCONTROL) inputCollection.add(curControl);
            if (curControl.Count() > 0) findControlsWithAttributes(Control startingControl, Collection<Control> inputCollection);
        }
    }
