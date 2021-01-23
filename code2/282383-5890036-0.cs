    public class Tag
    {
        private IList<ProjectTag> myProjectsTags;
    
        public virtual IEnumerable<ProjectTag> ProjectsTags
        {
            get
            {
                return new ReadOnlyCollection<ProjectTag>(myProjectsTags);
            }
    
            set
            {
                myProjectsTags = (IList<ProjectTag>)value;
            }
        }
    }
