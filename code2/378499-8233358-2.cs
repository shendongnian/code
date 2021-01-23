    var formsWithChildren = new List<Form>();
    foreach (var item in subForms.GroupBy(s => s.Form))
    {
        // re-use existing Form from grouping so it retains its assigned values
        Form f = item.Key;
        f.SubForms = item.Select(s => s).ToList();
        formsWithChildren.Add(f);
    }
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
