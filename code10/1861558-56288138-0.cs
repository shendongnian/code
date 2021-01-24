             Thread createComAndMessagePumpThread = new Thread(() =>
                {
                    axCZKEM1 = new zkemkeeper.CZKEMClass();
                    bool connSatus = axCZKEM1.Connect_Net(192.168.0.177, 4370);
                    if (connSatus == true)
                    {
                        this.axCZKEM1.OnAttTransactionEx -= new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                        if (axCZKEM1.RegEvent(1, 65535))//Here you can register the realtime events that you want to be triggered(the parameters 65535 means registering all)
                        {
                            
                            this.axCZKEM1.OnAttTransactionEx += new zkemkeeper._IZKEMEvents_OnAttTransactionExEventHandler(axCZKEM1_OnAttTransactionEx);
                        }
                    }
                    Application.Run();
                });
               
                createComAndMessagePumpThread.SetApartmentState(ApartmentState.STA);
                createComAndMessagePumpThread.Start();
            components = new System.ComponentModel.Container();
            this.ServiceName = "Service1";
        }
