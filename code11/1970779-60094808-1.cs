    protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
    {
        FieldInfo temp = this.ItemProvider.GetType().GetField("_officeVersion", BindingFlags.NonPublic | BindingFlags.Instance);
        uint officeVersion = (uint)temp.GetValue(this.ItemProvider);
        
        if (officeVersion == 15)
        {
            return new RibbonUpperCase();
        }
        else
        {
            return new RibbonTitleCase();
        }
    }
