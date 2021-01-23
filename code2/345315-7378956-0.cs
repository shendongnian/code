     public abstract class AnimatedSprite
     {
          public void LoadAnimations() 
          {
               OnLoadAnimations();
          }
          protected abstract void OnLoadAnimations();
          protected virtual void OnNextFrame() { };
          ....          
     }
