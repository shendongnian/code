     public class Missile {
       ...
       // In case of untracking missile we ignore its target
       public virtual void Update(Vector2 target) 
         => Update();
       protected void Update() {...}
     }
     public class TrackingMissile : Missile { 
       ...
       // In case of tracking we put target into account 
       public override void Update(Vector2 target) {...}       
     } 
     public class GuidedMissile : TrackingMissile { 
       ...
       public override void Update(Vector2 target) {
         // If target has been captured by radar
         if (IsTargetCaptured(target)) 
           base.Update(target); // ... approach to the target, 
         else 
           Update();            // otherwise just move forward
       }
     } 
