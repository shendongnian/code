    public string Name {
        get {
            if (SubItemCount == 0) {
                return string.Empty;
            }
            else {
                return subItems[0].Name;
            }
        }
        set {
            SubItems[0].Name = value;
        }
    }
