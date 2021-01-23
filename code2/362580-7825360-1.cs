    /// <summary>
    /// Gets the columns collection.
    /// </summary>
    [Browsable(true)]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    [PersistenceMode(PersistenceMode.InnerProperty)]
    public ItemCollection Items
    {
        get
        {
            if (itemCollection == null)
            {
                if (itemArrayList == null)
                {
                    this.EnsureChildControls();
                    if (itemArrayList == null)
                        itemArrayList = new ArrayList();
                }
                itemCollection = new ItemCollection(itemArrayList);
            }
            return itemCollection;
        }
    }
