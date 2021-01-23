    public class Effect {
    {
      private EffectManager _manager;
      public string Name {get;set;}
      public Effect(EffectManager manager) {
        _manager = manager;
      }
      public void ResetName() {
        Name = _manager.GetNextName();
      }
    }
    public class EffectManager {
      private List<Effect> Effects;
      private int currentIndex;
      public Effect CreateEffect() {
        var e = new Effect(this);
        Effects.Add(e);
      }
    
      public string GetNextName() {
        return "Effect " + currentIndex++;
      }
    
      public void ResetAllNames() {
        currentIndex = 0;
        foreach(var effect in Effects) {
          effect.Name = GetNextName();
        }
      }
    }
        
      
