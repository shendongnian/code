    public class DisplayClass
    {
        public DisplayClass(ModelClass mc)
        {
             this.mc = mc;
        }
        
        public string Name
        {
            get { return this.mc != null ? this.mc.Name : "New..."; }
        }
        public bool IsDummy
        {
            return this.mc == null;
        }
        public ModelClass Model
        {
            return this.mc;
        }
    }
