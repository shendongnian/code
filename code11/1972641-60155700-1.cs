        public override void Use(UseData useData)
        {
            if (Durability > 0)
            {
                base.Use(useData);
                Durability--;
            }
        }
