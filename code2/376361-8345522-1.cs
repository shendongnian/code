        public StructureMapRegistry ()
        {
            Scan (x => 
            {
                x.Convention<NestedInheritanceConvention> ();
            });
        }
