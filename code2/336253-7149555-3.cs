    internal class UserTreeBuilder
    {
        [ImportMany(AllowRecomposition=true)]
        public IEnumerable<IBuilder> Builders{ get; set; }
    
        public UserTreeBuilder()
        {
            // Load all builders from a MEF CompositionContainer
        }
    
        public void BuildUserTree(User user)
        {
            var builder = Builders.FirstOrDefault(b => b.CanHandleUserType(user.UserType));
        
            if(builder == null)
            {
                throw new Exception("No UserType set");
            }else{
                builder.BuildTree();
            }
        }
    }
