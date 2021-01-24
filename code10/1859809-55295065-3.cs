        // Write the data here
        //
        try
        {
            discFormatData.Write(fileSystem);
            e.Result = 0;
        }
        catch (COMException ex)
        {
            e.Result = ex.ErrorCode;
            MessageBox.Show(ex.Message, "IDiscFormat2Data.Write failed",
                MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
        finally
        {
            if (fileSystem != null)
            {
                Marshal.FinalReleaseComObject(fileSystem);
            }
        }
>        //
        // remove the Update event handler
        //
        discFormatData.Update -= discFormatData_Update;
