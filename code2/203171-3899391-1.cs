    private void ChangeIconStatus(string statusText)
    {
        Type type = this.GetType();
        System.Resources.ResourceManager resources =
        new System.Resources.ResourceManager(type.Namespace + ".Properties.Resources", this.GetType().Assembly);
        this.Icon = (System.Drawing.Icon)resources.GetObject(type.Namespace + ".Icons." + statusText + ".ico");
    }
