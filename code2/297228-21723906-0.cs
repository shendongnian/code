     /// <summary>
           /// Registers a call back for Device Events
           /// </summary>
            /// <param name="client">Object implementing IMMNotificationClient type casted as IMMNotificationClient interface</param>
           /// <returns></returns>
            public int RegisterEndpointNotificationCallback([In] [MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
            {
                return _realEnumerator.RegisterEndpointNotificationCallback(client);
    
            }
    
            /// <summary>
            /// UnRegisters a call back for Device Events
            /// </summary>
            /// <param name="client">Object implementing IMMNotificationClient type casted as IMMNotificationClient interface </param>
            /// <returns></returns>
            public int UnRegisterEndpointNotificationCallback([In] [MarshalAs(UnmanagedType.Interface)] IMMNotificationClient client)
            {
                return _realEnumerator.UnregisterEndpointNotificationCallback(client);
    
            } 
