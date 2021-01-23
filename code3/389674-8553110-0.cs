        //---------------------------------------------------------------------------------------------------------------------
        public class TriggerArgs
        {
            public AstroObject obj;
        }
    
        //---------------------------------------------------------------------------------------------------------------------
        public delegate void FireAction( AstroObject sender, TriggerArgs args );
    
        //---------------------------------------------------------------------------------------------------------------------
        public interface IFireable
        {
            void Fire( AstroObject sender, TriggerArgs args );
        }
    
        //---------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public abstract class Trigger : AstroObject
        {
            public Action Fired;
    
            public List<FireAction> Actions;
            protected abstract void CheckConditions( float Seconds );
            protected bool IsFired;
    
            public bool RearmOnFire = false;
    
            //---------------------------------------------------------------------------------------------------------------------
            protected override void LocalCreate( out int UpdateOrder )
            {
                UpdateOrder = Orders.Update.Trigger;
                IsFired = false;
            }
    
            //---------------------------------------------------------------------------------------------------------------------
            protected override void LocalDie( ) { }
    
            //---------------------------------------------------------------------------------------------------------------------
            public sealed override void Update( float Seconds )
            {
                CheckConditions( Seconds );
            }
    
            //---------------------------------------------------------------------------------------------------------------------
            protected void Fire( TriggerArgs args )
            {
                if ( IsFired ) return;
    
                foreach ( FireAction f in Actions ) f.Invoke( this, args );
    
                if ( Fired != null ) Fired( );
    
                IsFired = !RearmOnFire;
            }
    
            //---------------------------------------------------------------------------------------------------------------------
            public override void Render( Microsoft.Xna.Framework.Color color ) { }
        }
    
        //---------------------------------------------------------------------------------------------------------------------
        //---------------------------------------------------------------------------------------------------------------------
        public class TimeTrigger : Trigger
        {
            public float Interval;
            public float Elapsed;
    
            //---------------------------------------------------------------------------------------------------------------------
            protected override void LocalCreate( out int UpdateOrder )
            {
                base.LocalCreate( out UpdateOrder );
                Elapsed = Interval;
            }
    
            //---------------------------------------------------------------------------------------------------------------------
            public void Start( ) { Elapsed = Interval; IsFired = false; }
    
            //---------------------------------------------------------------------------------------------------------------------
            protected override void CheckConditions( float Seconds )
            {
                if ( IsFired ) return;
    
                Elapsed -= Seconds;
    
                if ( Elapsed <= 0 )
                {
                    Elapsed = Interval;
                    Fire( null );
                }
            }
        }
