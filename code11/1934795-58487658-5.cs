     public class Missile {
       ...
       // In case of untracking missile we ignore its target
       public virtual void Update(Vector2 target) 
         => Update();
       // No target: just moving forward
       protected void Update() {...}
     }
     public class TrackingMissile : Missile { 
       ...
       // In case of tracking missile we put target into account 
       public override void Update(Vector2 target) {...}       
     } 
