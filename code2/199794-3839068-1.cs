    public virtual ITemplate ItemListTemplate
    {
        get
        {
            if (itemListTemplate == null)
                itemListTemplate = ControlUtils.GetTemplate(<virtual path to template>, <resource file name>,
                    <type to determine assembly for template>);
            return itemListTemplate;
        }
        set
        {
            itemListTemplate = value;
        }
    }
