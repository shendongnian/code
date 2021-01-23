     private string metaInput { get; set; }
        public string MetaInput 
        {
            get
            {
                return metaInput;
            }
            set 
            {
                string x = value;
                if (x.Length > 3)
                {
                    if (x.EndsWith(" "))
                    {
                    string z = x.Replace(" ", "");
                    x = z.Replace(",", "");
                    int l = x.Length;
                        if (l > 2)
                        {
                            metaInput = null;
                            SaveMetaWord(x);
                        }
                        else 
                        {
                            metaInput = null;
                        }
                    }
                    
                }
                
                else 
                {
                    metaInput = value;
                }
            }
        }
