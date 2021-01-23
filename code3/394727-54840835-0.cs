    using AutoIt;
    
    class Program
    {
        static void Main(string[] args)
        {
            var buttonVisible = AutoItX.ControlCommand("Untitled - Notepad", "", "[CLASSNN:Edit1]", "IsVisible", "");
            //in your case it would be:
            //var buttonVisible = AutoItX.ControlCommand("Put the application title here", "", "[CLASSNN:AfxWnd90u21]", "IsVisible", "");
            
            if (buttonVisible == "1")
            {
                Console.WriteLine("Visible");
            } else
            {
                Console.WriteLine("Not visible");
            }  
        }
    }
