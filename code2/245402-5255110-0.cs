    public static class DllHelper
    {
        [System.Runtime.InteropServices.DllImport("Dll1.dll")]
        public static extern int function1();
    }
    private void buttonStart_Click(object sender, EventArgs e)
    {
        try
        {
            DllHelper.function1();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }      
