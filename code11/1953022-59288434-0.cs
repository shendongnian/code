    private void button1_Click(object sender, EventArgs e)
    {
        LoadFile();
    }
    private static int ProcessHeaderRow(string line)
    {
        int LoadRunNumber = 0;
        try
        {
            //some complex logic was here; error occurs here, so I throw an exception....
            throw new Exception("An Error Occurs -- Process Header Row Try block");
        }
        catch (CustomExceptionNoMessage e)
        {
            throw new CustomExceptionNoMessage(e.Message);
        }
        catch (Exception e)
        {
            //Process the exception, then rethrow, for calling code to also process the exception....
            //problem is here...XXXXXXXXXXXXXXXXXX
            throw new Exception(e.Message);  //crashes
        }
        return LoadRunNumber;
    }
    public static bool LoadFile()
    {
        int RunId = 0;
        try
        {
            RunId = ProcessHeaderRow("10~~happy~007909427AC");
            MessageBox.Show("Completed Upload to Cloud...");
        }
        catch (CustomExceptionNoMessage ce)
        {
            MessageBox.Show(ce.Message);
        }
        catch (System.IO.IOException e)   //CHANGED THIS LINE, AND I AM UP AND RUNNING (Changed to Exception e)
        {
            MessageBox.Show(e.Message);
        }
        return true;
    }
        public class CustomExceptionNoMessage : Exception
        {
            public CustomExceptionNoMessage()
            {
            }
            public CustomExceptionNoMessage(string message)
                : base(message)
            {
            }
            public CustomExceptionNoMessage(string message, Exception inner)
                : base(message, inner)
            {
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoadFile();
        }
