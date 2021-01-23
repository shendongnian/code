        private IPhysicalObject partOf;
        public IPhysicalObject PartOf
        {
            get { return partOf; }
            set
            {
                if (partOf != value)
                {
                    if (partOf != null)
                        partOf.Children.Remove(this.Designation);
                    partOf = value;
                    if (partOf != null)
                        partOf.Children.Add(this.Designation);
                }
            }
        }
        public virtual void Add(String key, IPhysicalObject value)
        {
            IPhysicalObject o;
            if (!TryGetValue(key, out o))
            {
                innerDictionary.Add(key, value);
                value.PartOf = Parent;
            }
        }
        public virtual bool Remove(String key)
        {
            IPhysicalObject o;
            if(TryGetValue(key, out o))
            {
                innerDictionary.Remove(key);
                o.PartOf = null;
            }
        }
