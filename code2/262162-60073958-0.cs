    using System.Threading;
    using AutoIt;
    //Namespace, class, function stuffs
    //New thread BEFORE create message box - safety measure
    Thread autoItThread = new Thread(delegate ()
                    {
                        AutoItX.WinWait("New Message box");
                        AutoItX.WinMove("New Message box", "This box will be moved", 400, 300);
                    });
                    autoItThread.Start();
    MessageBox.Show("This box will be moved", "New Message box");
