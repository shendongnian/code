    try
    {
        moCollection = moSearcher.Get();
    }
    catch (System.UnauthorizedAccessException)
    {
        return Program.ERROR_FUNCTION_FAILED;
    }
    catch (System.Runtime.InteropServices.COMException)
    {
        MessageBox.Show("Error, caught COMException.");
        return Program.ERROR_FUNCTION_FAILED;
    }
