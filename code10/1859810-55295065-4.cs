            discRecorder.EjectMedia();
        }
    }
    catch (COMException exception)
    {
        //
        // If anything happens during the format, show the message
        //
        MessageBox.Show(exception.Message);
        e.Result = exception.ErrorCode;
    }
    finally
    {
        if (discRecorder != null)
        {
            Marshal.ReleaseComObject(discRecorder);
        }
