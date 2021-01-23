    class Group : IGroup { .... }
    
    public class ContactUpdater
    {
        private IGroup _group;
    
        public ContactUpdater(IGroup group)
        {
            _group = group;
        }
    }
   
