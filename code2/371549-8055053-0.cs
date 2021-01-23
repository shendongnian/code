        public virtual SecurityInfo SecurityInfo
        {
            get
            {
                return new SecurityInfo(this.Username,this.Id);
            }
        }
