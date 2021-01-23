     public enum LayerType : int
    {
        
        [Description("محوطه")]
        Area = 1,
        
        [Description("ساختمان")]
        Building = 2,
        
        [Description("بارانداز")]
        Wharf = 3,}
    drpLayer.DataSource = Enum.GetValues(typeof(LayerType))
                 .Cast<Enum>()
                 .Select(value => new
            {
            (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
            value
             })
            .OrderBy(item => item.value)
            .ToList();
                drpLayer.DisplayMember = "Description";
                drpLayer.ValueMember = "value";
