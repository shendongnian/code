     private void onConnEst(IAsyncResult ar)
     {
          try
          {
               TcpClient client = (TcpClient)ar.AsyncState;
               if(client!=null && client.Client!=null)
               {
                    client.EndConnect(ar);
               }
          }
          catch(Exception ex){...}
     }
