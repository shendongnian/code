    public class SpaceTypeServices
    {
        public Guid CreateRequest(...)
        {    
            // rest  
            var spaceType = new SpaceType(spaceTypeInput);
            dbContext.SpaceTypes.Add(spaceType);
            dbContext.SaveChanges();
            return id;
        }
    }
