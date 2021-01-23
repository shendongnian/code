    public class Local<TValue>
    {
        static readonly Dictionary<object, object> StaticScope
            = new Dictionary<object, object>();
        static readonly Dictionary<object, Dictionary<object, object>> InstanceScope
            = new Dictionary<object, Dictionary<object, object>>();
    
    
        public TValue Value { get; set; }
    
    
        private Local() { }
    
    
        public static Local<TValue> Static( Action scope )
        {
            if ( !StaticScope.ContainsKey( scope ) )
            {
                Local<TValue> newInstance = new Local<TValue>();
                StaticScope.Add( scope, newInstance );                
            }
    
            return StaticScope[ scope ] as Local<TValue>;
        }
    
        public static Local<TValue> Instance<TScope>( Func<TScope> scope )
        {
            object instance = scope();
            if ( !InstanceScope.ContainsKey( instance ) )
            {                
                InstanceScope.Add( instance, new Dictionary<object, object>() );
    
                if ( !InstanceScope[ instance ].ContainsKey( scope ) )
                {
                    Local<TValue> newInstance = new Local<TValue>();
                    InstanceScope[ instance ].Add( scope, newInstance );
                }
            }
    
            return InstanceScope[ instance ][ scope ] as Local<TValue>;
        }
    }
