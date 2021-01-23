    protected class ItemListContainer : GenericContainer
    {
        public virtual Repeater RepeaterControl
        {
            get { return base.GetControl<Repeater>("repeater", true); }
        }
    }
