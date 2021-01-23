            private int? _oldHashCode;
    
            public override int GetHashCode()
            {
                // Once we have a hash code we'll never change it
                if( _oldHashCode.HasValue )
                {
                    return _oldHashCode.Value;
                }
    
                bool thisIsTransient = Equals (Id, default(TId));
    
    
                // When this instance is transient, we use the base GetHashCode()
                // and remember it, so an instance can NEVER change its hash code.
    
                if( thisIsTransient )
                {
                    _oldHashCode = base.GetHashCode ();
    
                    return _oldHashCode.Value;
                }
    
                return Id.GetHashCode ();
            }
