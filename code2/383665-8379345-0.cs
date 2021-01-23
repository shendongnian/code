    public static void DisplayMessageArea(string messageToDisplay)
    {
        MyControlWithTipIcon.TaskBarIcon.ToolTipText = messageToDisplay;
        MyControlWithTipIcon.TaskBarIcon.Visibility = ... //i.e. show the message
    }
