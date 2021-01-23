        public class  ComboSource
        {
            public string Name
            {
                get
                {
                    if (SourceValue != null)
                        return SourceValue.ToString();
                    return string.Empty;
                }
            }
            public Resource SourceValue{ get; set; }
    
        }
