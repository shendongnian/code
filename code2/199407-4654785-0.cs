    class TestEntity
    {
        public TestEntity BindingHack_ValueMember
        {
            get
            {
               return this;
            }
        }
        public string BindingHack_DisplayMember
        {
            get
            {
                return this.ToString();
            }
        }
    }
