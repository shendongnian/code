    // private : do not expose inner details; 
    // we have to manipulate with StringBuilder
    [DllImport(nativeLibName,
               CallingConvention = CallingConvention.Cdecl,
               EntryPoint = "GuiTextBox",
               CharSet = CharSet.Unicode)] //TODO: Provide the right encoding here
    private static extern bool CoreGuiTextBox(Rectangle bounds, 
                                              StringBuilder text, // We allow editing it
                                              int textSize, 
                                              bool freeEdit);
    
    // Here (in the public method) we hide some low level details
    // memory allocation, string manipulations etc.
    public static bool CoreGuiTextBox(Rectangle bounds, 
                                      ref string text, 
                                      int textSize, 
                                      bool freeEdit) {
      if (null == text)
        return false; // or throw exception; or assign "" to text
    
      StringBuilder sb = new StringBuilder(text);  
    
      // If we allow editing we should allocate enough size (Length) within StringBuilder
      if (textSize > sb.Length)
        sb.Length = textSize;
    
      bool result = CoreGuiTextBox(bounds, sb, sb.Length, freeEdit);   
      // Back to string (StringBuilder can have been edited)
      // You may want to add some logic here; e.g. trim trailing '\0'  
      text = sb.ToString();
    
      return result;
    }
