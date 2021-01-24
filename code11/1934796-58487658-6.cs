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
