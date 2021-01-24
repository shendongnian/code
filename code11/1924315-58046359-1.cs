    public DT_FLEQHeader Header
        {
            get
            {
                return this.headerField;
            }
            set
            {
                if(this.headerField == null)
                {
                     headerField = new DT_FLEQHeader();
                }     
                this.headerField = value;
            }
        }
