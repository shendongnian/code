    public class Tag
    {
        private IList<ProjectTag> projectsTags;
    
        public virtual IEnumerable<ProjectTag> ProjectsTags
        {
            get
            {
                return new ReadOnlyCollection<ProjectTag>(projectsTags);
            }
    
            set
            {
                projectsTags = (IList<ProjectTag>)value;
            }
        }
    }
