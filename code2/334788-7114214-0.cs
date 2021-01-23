            List<Action<Types.MessageBase<TMessageType>>> subscriptions;
            if (register.TryGetValue(typeof(TMessageType), out subscriptions))
            {
                foreach (var subscription in subscriptions)
                {
                    Console.WriteLine("Invoking....");
                    subscription(message);
                }
            }
