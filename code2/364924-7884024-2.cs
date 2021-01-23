    public sealed class DebugMenuItem : ToolStripMenuItem
    {
        private SpecificStateProvider _prov;
        public DebugMenuItem(SpecificStateProvider prov) : base("Debug Item")
        {
           _prov = prov;
        }
        // other stuff here
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            SpecificState state = _prov.GetState();
            if(state != null)
               state.MessWithStuff();
        }
    }
