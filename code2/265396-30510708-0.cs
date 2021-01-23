        public virtual Area Area { get; set; }
        public virtual string Nome { get; set; }
        public virtual string Descricao { get; set; }
        public virtual bool IsActive { get; set; }
        public virtual int Area_Id
        {
            get { return this.Area != null ? Area.Id : 0; }
        }
