private enum msgRet
		{
			conectionERROR,
            sendERROR,
            sucess
		}
	public int Print(string codToSend, string Print)
		{
			BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.DefaultAdapter;
			BluetoothSocket btSocket = null;
		    UUID MY_UUID = UUID.FromString("00001101-0000-1000-8000-00805F9B34FB");
			BluetoothDevice device = null;
			Stream outStream = null;
			int ret = -1;
            try
			{    
				MessagingCenter.Send(this, "Print");
				var MacAdress = mBluetoothAdapter.BondedDevices.ToList().Find(x => x.Name == Print).Address;
            
                if(string.IsNullOrEmpty(MacAdress)) 
                 return ret = (int)msgRet.sendERROR;
				if (!mBluetoothAdapter.IsEnabled)
				{
					BluetoothAdapter mBluetoothAdapter = 
 BluetoothAdapter.DefaultAdapter;
			      if(!mBluetoothAdapter.IsEnabled)
			      {
				    mBluetoothAdapter.Enable();
			      }
				}
				device = mBluetoothAdapter.GetRemoteDevice(MacAdress);
				btSocket = device.CreateInsecureRfcommSocketToServiceRecord(MY_UUID);
                
				if (!btSocket.IsConnected)
				{
					btSocket.Connect();
				}
				if (btSocket.IsConnected)
				{
					Thread.Sleep(200);
					try
					{                  
						byte[] msgBuffer = Encoding.ASCII.GetBytes(codToSend);
						outStream = btSocket.OutputStream;
						outStream.Write(msgBuffer, 0, msgBuffer.Length);
      				}
					catch (Exception e)
					{
						Debug.WriteLine("sendERROR" + e.Message);
						ret = (int)msgRet.sendERROR;
					}
				}
			} catch (Exception ex) {
				Debug.WriteLine("conectionERROR:" + ex.Message);
				ret = (int)msgRet.conectionERROR;
			}
			finally
			{
				if (outStream != null) { outStream.Close(); outStream.Dispose();}
                mBluetoothAdapter.Dispose();
				if (btSocket!=null) { btSocket.Close(); btSocket.Dispose(); }           
			}
			if (ret == -1) { ret = (int)msgRet.sucess; }
            
			return ret;
		}
