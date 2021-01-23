        public void AppenFromArray(T[] aSource)
        {
            if (aSource == null) { return; }
            foreach (T el in aSource)
            {
                this.Add(el);
            }
        }
