        while (NetworkingClient.DataMessages.Count > 0)
        {
            // once every two weeks a context switch happens to be here.
            DataMessage message = NetworkingClient.DataMessages.Dequeue();
    
            switch (message.messageType)
            {
               ...
            }
        }
