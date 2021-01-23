        Ping objPing = new Ping();
        
        try
        {
            PingReply objReply = objPing.Send(txtURL.Text, 1000);
            if (objReply.Status == IPStatus.Success)
            {
                lblProductName.Text = string.Format("<b>Success</b> - IP Address:{0} Time:{1}ms", objReply.Address, objReply.RoundtripTime);
            }
            else
            {
                lblProductName.Text = objReply.Status.ToString();
            }
        }
        catch (Exception ex)
        {
            lblProductName.Text = ex.Message;
        }
