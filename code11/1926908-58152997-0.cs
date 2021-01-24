            SignalGo.Client.ClientProvider clientProvider = new SignalGo.Client.ClientProvider();
            clientProvider.AddPriorityFunction(() =>
            {
                try
                {
                    //call login method
                }
                catch (Exception ex)
                {
                }
                return SignalGo.Client.PriorityAction.NoPlan;
            });
