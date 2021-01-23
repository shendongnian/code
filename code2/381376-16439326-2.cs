      ConsoleApplicationWCFClient.CCDB_HIG_service.ForDataset ds = obj.GetCCDBdata();
                string str = obj.GetCCDBdataasXMLstring();
            }
            catch (FaultException<ConsoleApplicationWCFClient.CCDB_HIG_service.ServiceData> Fex)
          {
              Console.WriteLine("ErrorMessage::" + Fex.Detail.ErrorMessage + Environment.NewLine);
              Console.WriteLine("ErrorDetails::" + Environment.NewLine + Fex.Detail.ErrorDetails);
              Console.ReadLine();
          }
