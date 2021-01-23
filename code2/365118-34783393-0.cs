        /// <summary>
        /// Corresponds to 
        ///     control.Click += new EventHandler(method);
        /// Only done dynamically, and event arguments are omitted.
        /// </summary>
        /// <param name="objWithEvent">Where event resides</param>
        /// <param name="objWhereToRoute">To which object to perform execution to</param>
        /// <param name="methodName">Method name which to call. 
        ///  methodName must not take any parameter in and must not return any parameter. (.net 4.6 is strictly checking this)</param>
        private static void ConnectClickEvent( object objWithEvent, object objWhereToRoute, string methodName )
        {
            EventInfo eventInfo = null;
            foreach (var eventName in new String[] { "Click" /*WinForms notation*/, "ItemClick" /*DevExpress notation*/ })
            {
                eventInfo = objWithEvent.GetType().GetEvent(eventName);
                if( eventInfo != null )
                    break;
            }
            
            Type objWhereToRouteObjType = objWhereToRoute.GetType();
            var method = eventInfo.EventHandlerType.GetMethod("Invoke");
            List<Type> types = method.GetParameters().Select(param => param.ParameterType).ToList();
            types.Insert(0, objWhereToRouteObjType);
            
            var methodInfo = objWhereToRouteObjType.GetMethod(methodName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[0], null);
            if( methodInfo.ReturnType != typeof(void) )
                throw new Exception("Internal error: methodName must not take any parameter in and must not return any parameter");
            
            var dynamicMethod = new DynamicMethod(eventInfo.EventHandlerType.Name, null, types.ToArray(), objWhereToRouteObjType);
            ILGenerator ilGenerator = dynamicMethod.GetILGenerator(256);
            ilGenerator.Emit(OpCodes.Ldarg_0);
            ilGenerator.EmitCall(OpCodes.Call, methodInfo, null);
            ilGenerator.Emit(OpCodes.Ret);
            var methodDelegate = dynamicMethod.CreateDelegate(eventInfo.EventHandlerType, objWhereToRoute);
            eventInfo.AddEventHandler(objWithEvent, methodDelegate);
        } //ConnectClickEvent
