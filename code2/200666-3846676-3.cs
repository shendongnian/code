    //
    // WARNING: very very rough code here !!
    //
    public class DynamicEvent
    {
        List<Delegate> delegates;
    
        public DynamicEvent()
        {
            delegates = new List<Delegate>();
        }
        public void AddHandler(Delegate dlgt)
        {
            delegates.Add(dlgt);
        }
        public void Invoke(params object[] args)
        {
            foreach (var del in delegates)
            {
                var parameters = del.Method.GetParameters();
                // check parameters number
                if (args.Length != parameters.Length)
                    continue; // go to next param
    
                // check parameters assignability
                bool assignable = true;
                for (int i = 0; i < args.Length; i++)
                {
                    if (!parameters[i].ParameterType.IsInstanceOfType(args[i]))
                    {
                        assignable = false;
                        break; // stop looping on parameters
                    }
                }
                if (!assignable)
                    continue; // go to next param
    
                // OK it seems compatible, let's invoke
                del.DynamicInvoke(args);
            }
        }
    }
