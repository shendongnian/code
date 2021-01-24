        private static void RegisterNetworkMethods(Type type, INetworkEnabled obj)
        {
            // get the methods of this type that have the NetworkMethodAttribute
            var methods = (from m in type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance)
                           where m.GetCustomAttributes(false).OfType<NetworkMethodAttribute>().Count() > 0
                           select m).ToList();
            foreach(var method in methods)
            {
                // get the NetworkMethodAttribute Message variable that was assigned
                var message = method.GetCustomAttribute<NetworkMethodAttribute>().Message;
                var action = (Action<dynamic>) Delegate.CreateDelegate(typeof(Action<dynamic>), method);
                
                networkHooks.Add(message, action);
            }
        }
