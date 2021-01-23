     public void PrintShippingLabels()
        {
            
            //mock of what the reset of the program will produce up to this step
            List<string> shippingLabels = new List<string>();
            for (var i = 0; i < 10; i++)
            {
                var trackingNumber = "1ZR02XXXXXXXXXXXXX" + i + ".gif";
                shippingLabels.Add(trackingNumber);
                CreateSampleShippingLabel(trackingNumber);
            }
            Assert.AreEqual(10, shippingLabels.Count);
            IceTechUPSClient.Instance.PrintLabels("", shippingLabels);
        }
      public void PrintLabels(List<string> shippingLabels)
        {
            //this is where I print to printer...
            PrintDocument pd = new PrintDocument();
            foreach (string labelPath in shippingLabels)
            {  
                pd.Print();
            }
        }
