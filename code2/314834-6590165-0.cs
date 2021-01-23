    double bytesSent = 0.0;
    if(double.TryParse(lblBytesSent.Text, out bytesSent))
    {
        int bytesSentSpeed = (int)(interfaceStats.BytesSent - bytesSent) / 1024;
    }
