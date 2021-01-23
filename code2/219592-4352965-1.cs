       [CompilerGenerated, DebuggerDisplay(@"\{ x = {x}, y = {y} }", Type="<Anonymous Type>")]
    internal sealed class <>f__AnonymousType0<<x>j__TPar, <y>j__TPar>
    {
        // Fields
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <x>j__TPar <x>i__Field;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly <y>j__TPar <y>i__Field;
    
        // Methods
        [DebuggerHidden]
        public <>f__AnonymousType0(<x>j__TPar x, <y>j__TPar y)
        {
            this.<x>i__Field = x;
            this.<y>i__Field = y;
        }
    
        [DebuggerHidden]
        public override bool Equals(object value)
        {
            var type = value as <>f__AnonymousType0<<x>j__TPar, <y>j__TPar>;
            return (((type != null) && EqualityComparer<<x>j__TPar>.Default.Equals(this.<x>i__Field, type.<x>i__Field)) && EqualityComparer<<y>j__TPar>.Default.Equals(this.<y>i__Field, type.<y>i__Field));
        }
    
        [DebuggerHidden]
        public override int GetHashCode()
        {
            int num = -576933007;
            num = (-1521134295 * num) + EqualityComparer<<x>j__TPar>.Default.GetHashCode(this.<x>i__Field);
            return ((-1521134295 * num) + EqualityComparer<<y>j__TPar>.Default.GetHashCode(this.<y>i__Field));
        }
    
        [DebuggerHidden]
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("{ x = ");
            builder.Append(this.<x>i__Field);
            builder.Append(", y = ");
            builder.Append(this.<y>i__Field);
            builder.Append(" }");
            return builder.ToString();
        }
    
        // Properties
        public <x>j__TPar x
        {
            get
            {
                return this.<x>i__Field;
            }
        }
    
        public <y>j__TPar y
        {
            get
            {
                return this.<y>i__Field;
            }
        }
    }
 
 
