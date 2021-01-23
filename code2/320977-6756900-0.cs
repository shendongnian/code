     private void onConnEst(IAsyncResult ar)
     {
          try
          {
               TcpClient client = (TcpClient)ar.AsyncResult;
               if(client!=null && client.Client!=null)
               {
                    client.EndConnect(ar);
               }
          }
          catch(Exception ex){...}
     }
