    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public ScriptReferenceCollection ScriptReferences
    {
        get
        {
            if (scriptReferenceCollection == null)
            {
                if (scriptReferenceArrayList == null)
                {
                    this.EnsureChildControls();
                    if (scriptReferenceArrayList == null)
                        scriptReferenceArrayList = new ArrayList();
                }
                scriptReferenceCollection = new ScriptReferenceCollection(scriptReferenceArrayList);
            }
            return scriptReferenceCollection;
        }
    }
