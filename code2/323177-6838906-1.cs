    public class StaticDynamicWrapper : DynamicObject
    {    
        private Type _type;
        public StaticDynamicWrapper(Type type) { _type = type; }
        private static readonly IList< Func<Type, string, object[],object>> CallSiteInvokers;
        /// <summary>
        /// Static initializer. Used to improve performance so we only need to resolve the right Func type, once.
        /// </summary>
        static StaticDynamicWrapper()
        {
            CallSiteInvokers = new List< Func< Type, string, object[],object>>();
           
            //Get the max number of arguments allowed by the built in Func types.
            var funcTypes = Assembly.GetAssembly(typeof (Func<>)).GetTypes().Where(t => t.Name.StartsWith("Func`"))
                .Concat(Assembly.GetAssembly(typeof (Func<,,,,,,,,,,,,>)).GetTypes().Where(t => t.Name.StartsWith("Func`")))
                .OrderBy(t => t.GetGenericArguments().Count()).ToArray();
            int maxNoOfArgs = funcTypes.Max(t => t.GetGenericArguments().Length) - 2; //We need to subtract 3 from the absolute max to account for the return type and the 2 required parameters: callsite and target type. Plus 1 to offset the indexing
            //Index the function calls based on the number of parameters in the arguments.
            for(int i = 0; i < maxNoOfArgs; i++)
            {
                int funcIndex = i + 2;
                
                CallSiteInvokers.Add
                    (
                        ( type, name ,objects) =>
                            {
                                //The call site pre/post fixes.
                                var funcGenericArguments = new List<Type>() { typeof(CallSite), typeof(object), typeof(object) };
                                
                                //The argument info collection
                                var argumentInfoCollection = new List<CSharpArgumentInfo>()
                                               {
                                                   CSharpArgumentInfo.Create(
                                                       CSharpArgumentInfoFlags.UseCompileTimeType |
                                                       CSharpArgumentInfoFlags.IsStaticType,
                                                       null)
                                               };
                                //Set up the generic arguments for objects passed in.
                                funcGenericArguments.InsertRange(2,objects.Select(o => o.GetType()));
                                //Set up the argument info for the inner binder.
                                argumentInfoCollection.AddRange(objects.Select(o=> CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)));
                                var innerBinder = Binder.InvokeMember(
                                    CSharpBinderFlags.None, name, null, null, argumentInfoCollection.ToArray()                                    
                                );
                                //Dynamically instantiate the generic CallSite, by calling on the "Create" factory method.
                                var callSite = typeof (CallSite<>)
                                    .MakeGenericType(
                                        funcTypes[funcIndex]
                                        .MakeGenericType(funcGenericArguments.ToArray())
                                    )
                                    .GetMethod("Create")
                                    .Invoke(null,new object[]{innerBinder});
                                
                                //Dynamically invoke on the callsite target.
                                object invokingDelegate = callSite.GetType().GetField("Target").GetValue(callSite);
                                return invokingDelegate.GetType().GetMethod("Invoke").Invoke(invokingDelegate,
                                    new object[]
                                                    {
                                                        callSite, 
                                                        type
                                                    }.Concat(objects).ToArray());                                       
                                
                            }
                    );
            }
        }
        
        
        /// <summary>
        /// Handle static property accessors.
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo prop = _type.GetProperty(binder.Name, BindingFlags.FlattenHierarchy | BindingFlags.Static | BindingFlags.Public);        
            if (prop == null)
            {
                result = null;            
                return false;
            }         
            result = prop.GetValue(null, null);        
            return true;
        }   
  
        /// <summary>
        /// Handle static methods
        /// </summary>
        /// <param name="binder"></param>
        /// <param name="args"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            try
            {
                result = CallSiteInvokers[args.Length](_type, binder.Name, args);
                return true;
            }
            catch (RuntimeBinderException)
            {
                result = null;
                return false;
            }  
        }
    }
