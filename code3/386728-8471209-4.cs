    public class ThisDebugHandler: AbstractDebugHandler<ThisType>{
        public ThisDebugHandler(ThisType innerObject) : base(innerObject){
        }
       
        public override GetDebugString(){
            return InnerObject.Rotation;
        }
    }
