    public class ClassImTesting  {
        public Thing Translate(IlistOfThings listOfthings){
            var thing = listOfthings.MyList.SingleOrDefault(lt => lt.Name== "NameToFind");
            
            return thing
        }
    }
    
