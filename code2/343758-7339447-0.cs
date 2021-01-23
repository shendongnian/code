    public class rtbEx : RichTextBox
    {
      [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
      static extern IntPtr LoadLibrary(string lpFileName);
    
      protected override CreateParams CreateParams
      {
        get
        {
          var prams = base.CreateParams;
          if (LoadLibrary("msftedit.dll") != IntPtr.Zero)
            prams.ClassName = "RICHEDIT50W";
          return prams;
        }
      }
    }
