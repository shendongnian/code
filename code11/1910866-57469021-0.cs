    public static class ExtensionMethods
    {
        public static void EnableMeshRenderers(this Transform trans, bool enable, string name = "")
        {
            var renderers = trans.GetComponentsInChildren<MeshRenderer>();
            EnableMeshRenderers(renderers, enable, name);
        }
        public static void EnableMeshRenderers(this GameObject go, bool enable, string name = "")
        {
            var renderers = go.GetComponentsInChildren<MeshRenderer>();
            EnableMeshRenderers(renderers, enable, name);
        }
        public static void EnableMeshRenderers(
            this IEnumerable<MeshRenderer> meshRenderers, bool enable, string name)
        {
            foreach (MeshRenderer meshRenderer in meshRenderers)
            {
                if (string.IsNullOrWhiteSpace(name))
                    meshRenderer.enabled = enable;
                else if (string.Equals(meshRenderer.gameObject.name, name, StringComparison.OrdinalIgnoreCase))
                    meshRenderer.enabled = enable;
            }
        }
    }
