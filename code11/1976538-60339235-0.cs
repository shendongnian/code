    public class PropHolder
        {
            [Parameter]
            public PropertyInfo info { get; set; }
            [Parameter]
            public string type { get; set; }
            public PropHolder(PropertyInfo nfo, string propType)
            {
                info = nfo;
                type = propType;
            }
        }
