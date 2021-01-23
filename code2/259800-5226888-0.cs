    using System;
    using System.Windows.Forms;
    
    internal class NumericUpDownControl : NumericUpDown
    {
    #region Constants
    protected const String UpKey = "{UP}";
    protected const String DownKey = "{DOWN}";
    #endregion Constants
    
    #region Base Class Overrides
    protected override void OnMouseWheel(MouseEventArgs e_)
    {
        String key = GetKey(e_.Delta);
        SendKeys.Send(key);
    }
    #endregion Base Class Overrides
    
    #region Protected Methods
    protected static String GetKey(int delta_)
    {
        String key = (delta_ < 0) ? DownKey : UpKey;
        return key;
    }
    #endregion Protected Methods
    } 
