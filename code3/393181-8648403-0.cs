        public delegate string IncomingMessageHook(int id);
        public event IncomingMessageHook InComingMessage;
        private string OnInComingMessage(int id)
        {
            IncomingMessageHook handler = null;
            Delegate[] targets = null;
            string result;
            handler = InComingMessage;
            if (handler != null)
            {
                targets = handler.GetInvocationList();
                foreach (Delegate target in targets)
                {
                    try
                    {
                        handler = (IncomingMessageHook)target;
                        result = handler.Invoke(id);
                        if (!String.IsNullOrEmpty(result))
                        {
                            break;
                        }
                    }
                    catch (Exception ex)
                    {
                    }
                }
            }
            return result;
       }
