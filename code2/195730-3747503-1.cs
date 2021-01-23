    public abstract class bobase
        {
            internal virtual Type DBclass
            {
                get
                {
                    return Type.GetType(this.GetType().Name + "DB");
                }
            }
        }
