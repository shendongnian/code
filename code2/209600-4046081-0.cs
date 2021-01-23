    protected virtual void OnFormat(ConvertEventArgs cevent)
    {
        if (this.onFormat != null)
        {
            this.onFormat(this, cevent);
        }
        if (((!this.formattingEnabled && !(cevent.Value is DBNull)) && ((cevent.DesiredType != null) && !cevent.DesiredType.IsInstanceOfType(cevent.Value))) && (cevent.Value is IConvertible))
        {
            cevent.Value = Convert.ChangeType(cevent.Value, cevent.DesiredType, CultureInfo.CurrentCulture);
        }
    }
 
