    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [MTAThread]
    static void Main() {
      ShowWindowsMenu(false);
      try {
        Application.Run(new Form());
      } catch (Exception err) {
        // Log my error
      } finally {
        ShowWindowsMenu(true);
      }
    }
