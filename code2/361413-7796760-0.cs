    IEnumerable MyFunc(...){
        IAsyncResult res = mSocket.BeginReceive(mReceptionArray, 0, pNbBytes, SocketFlags.None, null, null);
        while (!res.IsCompleted){
            yield return null; // It seems you con't need new WaitForFixedUpdate() really! 
        }
    }
