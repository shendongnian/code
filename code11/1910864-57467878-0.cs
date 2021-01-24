    public static void EnableMeshRenderers(this Transform trans, bool _enable, string _name = "")
    {
        foreach (MeshRenderer meshRenderer in trans.GetComponentsInChildren<MeshRenderer>())
        {
            if (string.IsNullOrWhiteSpace(_name))
                meshRenderer.enabled = _enable;
            else if (meshRenderer.gameObject.name.ToUpper().Equals(_name.ToUpper()))
                meshRenderer.enabled = _enable;
        }
    }
    public static void EnableMeshRenderers(this GameObject go, bool _enable, string _name = "") => go.transform.EnableMeshRenderers(_enable, _name);
