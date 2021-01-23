      abstract class ProfileFactory 
        { 
            public abstract IProfile GetProfile(Page p); //Factory Method Declaration 
        }
    
    class concreteFactoryforProfile1 : ProfileFactory 
        {
        public override IProfile GetProfile(Page p) //Factory Method Implementation 
                { 
                    //data access stuff...
                    return new Profile() { Page = p }; 
                } 
        }
    
    class concreteFactoryforProfile2 : ProfileFactory 
        {
        public override IProfile GetProfile(Page p) //Factory Method Implementation 
                { 
                    //other data access stuff...
                    return new Profile() { Page = p };
                } 
        }
    
    
    interface IProfile 
        { 
            Page Page { get; set; } 
            //other properties can come here
        }
    
    class Profile : IProfile
        { 
            public  Page Page { get; set; }
            //other properties can come here
        }
    
    
    public class Test
    {
        void Main()
        {
    
            ProfileFactory[] objFactories = new ProfileFactory[2];
            objFactories[0] = new concreteFactoryforProfile1();
            objFactories[1] = new concreteFactoryforProfile2();
            foreach (ProfileFactory objFactory in objFactories)
            {
                IProfile objProfile = objFactory.GetProfile(this.Page);
                Page p = objProfile.Page;
            }
        }
    }
