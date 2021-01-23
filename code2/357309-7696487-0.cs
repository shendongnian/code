            public override bool Equals( object obj )
            {
                Entity<TId> other = obj as Entity<TId>;
    
                if( other == null || this.GetType() != other.GetType() )
                {
                    return false;
                }
    
                bool otherIsTransient = Equals (other.Id, default(TId));
                bool thisIsTransient = Equals (this.Id, default (TId));
    
                if( otherIsTransient && thisIsTransient )
                {
                    return ReferenceEquals (this, other);
                }
    
                return Id.Equals (other.Id);
    
            }
