    private void Execute(object sender, EventArgs e)
        {
            /// Get Open Documents
            string docName = GetActiveTextEditor();
            if (docName == null) return;
        }
    internal static string GetActiveTextEditor()
        {
            DTE dte = Package.GetGlobalService(typeof(SDTE)) as DTE;
            string docName = dte.ActiveDocument.Name;
            return docName;
        }
