    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        Script script = GameObject.Find("GameObject").GetComponent<Script>();
        script.dialogue.Add(new Dialogue());
        EditorUtility.SetDirty(script);
    }
 
