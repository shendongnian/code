    [Bind(Include = WhiteList)]
    public class ElephantModel : AnimalModel {
    
      new protected const string WhiteList = AnimalModel.WhiteList + ",TrunkLength,Personality";
    }  
  
