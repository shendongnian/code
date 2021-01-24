    using System.Linq;
    ...
 
    private string[] m_ServerValues = null;
    // Pure buiness logic: ServerValues without any UI (form)
    public string[] ServerValues {
      get { 
        // If we have the array we return it
        if (m_ServerValues != null)
          return m_ServerValues;
        // otherwise we compute it
        m_ServerValues = File
          .ReadLines("c:\\toyotoconsole\\tssetup.txt")
          .SelectMany(line => line.Split('|'))
          .ToArray();
        // And return it
        return m_ServerValues;
      } 
    }
    // UI: form loading
    private void frmExecute_Load(object sender, EventArgs e) {
      // If you want to prefetch (it's not necessary)
      var values = ServerValues;
    } 
