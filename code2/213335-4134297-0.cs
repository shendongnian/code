    private List<string> m_files
    [EditorAttribute(typeof(System.ComponentModel.Design.CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
    public List<string> Files
    {
        get
        {
            return m_files;
        }
        set
        {
            m_files = value;
        }
    }
