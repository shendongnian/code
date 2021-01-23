        public void ConnectivityChanged(NLM_CONNECTIVITY newConnectivity)
        {
            if (newConnectivity == NLM_CONNECTIVITY.NLM_CONNECTIVITY_DISCONNECTED ||
                ((int)newConnectivity & (int)NLM_CONNECTIVITY.NLM_CONNECTIVITY_IPV4_NOTRAFFIC) != 0)
            {
                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                    delegate()
                    {
                        buttonStart.Visibility = Visibility.Hidden;
                    }
                ));
            }
            // ...
        }
