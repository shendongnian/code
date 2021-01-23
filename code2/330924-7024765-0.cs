    using System;
    using System.Threading;
    using System.Diagnostics;
    public class TerminateProcessExample {
    public static void Main () {
        // Create a new Process and run notepad.exe.
        using (Process process = Process.Start("notepad.exe")) {
            // Wait for 5 seconds and terminate the notepad process.
            Console.WriteLine("Waiting 5 seconds before terminating" +
                " notepad.exe.");
            Thread.Sleep(5000);
            // Terminate notepad process.
            Console.WriteLine("Terminating Notepad with CloseMainWindow.");
            // Try to send a close message to the main window.
            if (!process.CloseMainWindow()) {
                // Close message did not get sent - Kill Notepad.
                Console.WriteLine("CloseMainWindow returned false - " +
                    " terminating Notepad with Kill.");
                process.Kill();
            } else {
                // Close message sent successfully; wait for 2 seconds
                // for termination confirmation before resorting to Kill.
                if (!process.WaitForExit(2000)) {
                    Console.WriteLine("CloseMainWindow failed to" +
                        " terminate - terminating Notepad with Kill.");
                    process.Kill();
                }
            }
        }
        // Wait to continue.
        Console.WriteLine("Main method complete. Press Enter.");
        Console.ReadLine();
    }
    }
