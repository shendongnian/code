        private bool propC_set=false;
        private date pC;
        public date C {
            get{
                return pC;
            }
            set{
                if (!propC_set) {
                   pC = value;
                }
                propC_set = true;
            }
        }
