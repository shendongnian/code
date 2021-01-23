                // duplex session enable http binding
                WSDualHttpBinding httpBinding = new WSDualHttpBinding(WSDualHttpSecurityMode.None);
                httpBinding.ReceiveTimeout = TimeSpan.MaxValue;
                httpBinding.ReliableSession = new ReliableSession();
                httpBinding.ReliableSession.Ordered = true;
                httpBinding.ReliableSession.InactivityTimeout = TimeSpan.MaxValue;
