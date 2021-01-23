    public class MyTargetType
    {
        public override bool Equals( object obj )
        {
            return ( obj is MyTargetType )
                        ? this.ID == ( ( MyTargetType ) obj ).ID
                        : false;
        }
    }
