    namespace PCComm
    {
        class CommunicationManager
        {
        #region OpenPort
        public bool OpenPort(BluMote.SettingsForm form)
        {
            try
            {
                if (comPort.IsOpen == true) comPort.Close();
                comPort.BaudRate = int.Parse(_baudRate);
                comPort.DataBits = int.Parse(_dataBits);
                comPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), _stopBits);
                comPort.Parity = (Parity)Enum.Parse(typeof(Parity), _parity);
                comPort.PortName = _portName;
                comPort.Open();
                //PCComm.frmMain form = new PCComm.frmMain();
                form.send2Display("test");
                return true;
            }
            catch (Exception ex)
            {
                DisplayData(MessageType.Error, ex.Message);
                return false;
            }
        }
        #endregion
    }
    }
