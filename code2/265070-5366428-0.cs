    [Bind(Include = WhiteList)]
    public class ElephantModel : AnimalModel {
    
      new public const string WhiteList = AnimalModel.WhiteList + ",TrunkLength,Personality";
    }  
  
