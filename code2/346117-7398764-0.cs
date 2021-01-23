    public string Category
    {
        get
        {
            if (!this.localized)
            {
                this.localized = true;
                string localizedString = this.GetLocalizedString(this.categoryValue);
                if (localizedString != null)
                {
                    this.categoryValue = localizedString;
                }
            }
            return this.categoryValue;
         }
    }
