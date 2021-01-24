    catch (COMException ex)
    {
        uint errorCode = (uint)ex.ErrorCode;
        if (errorCode == 0x80210003)
        {
            // handle "There are no documents in the document feeder"
        }
        else
        {
            MessageBox.Show(ex.Message);
        }
    }
