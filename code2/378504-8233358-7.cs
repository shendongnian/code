    public class Form
    {
        public int FormId { get; set; }
        public virtual ICollection<SubForm> SubForms{ get; set; }
        
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            
            Form f = obj as Form;            
            return this.Equals(f);
        }
        
        public bool Equals(Form f)
        {
            if (f == null)
                return false;
                
            return this.FormId == f.FormId;
        }
        
        public override int GetHashCode()
    	{
    		return this.FormId.GetHashCode();
    	}
    }
