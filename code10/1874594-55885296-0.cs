    catch (Exception ex) {
        var inner = ex.InnerException as SocketException;
        if (inner != null && inner.SocketErrorCode == SocketError.ConnectionReset)
            ShowMessage("Disconnected");
        else
            ShowMessage(ex.Message);
    ...
