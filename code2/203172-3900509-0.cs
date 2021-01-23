    Type type = this.GetType(); 
    System.Resources.ResourceManager resources = 
    new System.Resources.ResourceManager(type.Namespace + ".Properties.Resources", this.GetType().Assembly);
    // here it comes, call GetObject just with the resource name, no namespace and no extension
    this.Icon = (System.Drawing.Icon)resources.GetObject(statusText); 
