        uint dummy = 0;
        byte[] inOptionValues = new byte[Marshal.SizeOf(dummy) * 3];
        //set keepalive on
        BitConverter.GetBytes((uint)1).CopyTo(inOptionValues, 0); 
        //interval time between last operation on socket and first checking. example:5000ms=5s
        BitConverter.GetBytes((uint)5000).CopyTo(inOptionValues, Marshal.SizeOf(dummy));
        //after first checking, socket will check serval times by 1000ms.
        BitConverter.GetBytes((uint)1000).CopyTo(inOptionValues, Marshal.SizeOf(dummy) * 2);
        Socket socket = __Client.Client;
        socket.IOControl(IOControlCode.KeepAliveValues, inOptionValues, null);
