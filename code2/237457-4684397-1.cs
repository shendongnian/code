        //Holds our processor classes, each identified by IP
        private Dictionary<IPAddress, Processor> Processors = new Dictionary<IPAddress,Processor>();
                
        private void dataReceived(Byte[] data, IPAddress ip)
        {
            //If we don't already have the IP Address in our dictionary
            if(!Processors.ContainsKey(ip)){
                //Create a new processor object and add it to the dictionary
                Processors.Add(ip, new Processor());
            }
            //At this point we've either just added a processor for this IP
            //or there was one already in the dictionary so grab it based
            //on the IP
            Processor p = Processors[ip];
            //Tell it to process our data
            p.ProcessPacket(data);
        }
