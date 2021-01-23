    private T GetControl<T>(ASPxGridView control, string element)
        where T: System.Web.UI.Control
    {
        return (T)(object)control.FindEditFormTemplateControl(element);
    }
