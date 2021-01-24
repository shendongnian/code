    [AttributeUsage(AttributeTargets.Parameter)]
    public class EventKeyAttribute : Attribute
    {
    }
    [PSerializable]
    public class EventAttribute : OnMethodBoundaryAspect
    {
        private int keyPosition;
        public override void CompileTimeInitialize( MethodBase method, AspectInfo aspectInfo )
        {
            this.keyPosition = -1;
            // Go through method's arguments and find the key position.
            foreach (var param in method.GetParameters())
            {
                if (param.IsDefined(typeof(EventKeyAttribute)))
                {
                    if (this.keyPosition != -1)
                    {
                        // Build time error.
                        Message.Write( param, SeverityType.Error, "ERR001", $"Multiple parameters of {method} are marked with [EventKey]." );
                        return;
                    }
                    this.keyPosition = param.Position;
                }
            }
            if (this.keyPosition == -1)
            {
                // Build time error.
                Message.Write( method, SeverityType.Error, "ERR002", $"No parameter of {method} is marked with [EventKey]." );
            }
        }
        public override void OnSuccess( MethodExecutionArgs args )
        {
            Console.WriteLine( $"Key is: {args.Arguments[this.keyPosition]}" );
        }
    }
