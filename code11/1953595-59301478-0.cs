     public async Task Connect()
       {
            await Task.Delay(5000);
            Task.Factory.StartNew(() => ZkemClientObj.Connect_Net(ip, port));
       }
