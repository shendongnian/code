     class ServerProgram
     { 
          static stKey;
          static stValue;
          ....
          ....      
                        case Commands.UpdateValue: //obtain update requester client-ID                            
                            stKey = client.ReadString(); //read key 
                            stValue = client.ReadString(); //read val
                            ....
                            ....
                        case Commands.Yes:
                            Console.WriteLine(stKey + ", " + stValue);
                            KeyValueDictionary[stKey].Value = stValue;
                            client.Write(stKey + " is updated.");
                            break;
         }
