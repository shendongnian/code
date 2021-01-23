    [ComVisible(true)]
    public class ReadOnlyFileIconOverlayHandler : SharpIconOverlayHandler
    {
      protected override int GetPriority()
      {
        //  The read only icon overlay is very low priority.
        return 90;
      }
      protected override bool CanShowOverlay(string path, FILE_ATTRIBUTE attributes)
      {
        try
        {
          //  Get the file attributes.
          var fileAttributes = new FileInfo(path);
 
          //  Return true if the file is read only, meaning we'll show the overlay.
          return fileAttributes.IsReadOnly;
        }
        catch (Exception) { return false; }
      }
 
      protected override System.Drawing.Icon GetOverlayIcon()
      {
        //  Return the read only icon.
        return Properties.Resources.ReadOnly;
      }
    }
