`
static readonly object _Lock = new object();
private void transmit(byte write_bytes)
        {
            lock (_Lock)
            {
                try
                {
                    if (usb_found == 1) USB_PORT.Write(SerBuf, 0, write_bytes);      // writes specified amount of SerBuf out on COM port
                }
                catch (Exception)
                {
                    usb_found = 0;
                    MessageBox.Show("write fail");
                    return;
                }
            }
        }
private void receive(byte read_bytes)
        {
            lock (_Lock)
            {
                byte x;
                for (x = 0; x < read_bytes; x++)       // this will call the read function for the passed number times, 
                {                                      // this way it ensures each byte has been correctly recieved while
                    try                                // still using timeouts
                    {
                        if (usb_found == 1) USB_PORT.Read(SerBuf, x, 1);     // retrieves 1 byte at a time and places in SerBuf at position x
                    }
                    catch (Exception)                                       // timeout or other error occured, set lost comms indicator
                    {
                        usb_found = 0;
                        MessageBox.Show("read fail");
                        return;
                    }
                }
            }
        }
`
