    public class LocalDescriptionAttribute : DescriptionAttribute
    {
        public string ResourceKey { get; set; }
        public string CultureCode { get; set; }
        //you can set a default value of CultureCode
        //so that you needn't set it everywhere
        public override string Description
        {
            get
            {
                //core of this attribute
                //first find the corresponding resource file by CultureCode
                //and then get the description text by the ResourceKey
            }
        }
    }
