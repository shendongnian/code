    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Threading;
    class ExampleClass
    {
        private Process myProcess = new Process();
        private bool finishedFlag = false;
        // Print a file with any known extension.
        public void ConvertVideo(string fileName)
        {
            try
            {
                /* start the process */
                myProcess.StartInfo.FileName = "convert.exe"; /* change this */
                /* if the convert.exe app accepts one argument containing
                   the video file, the line below does this */
                myProcess.StartInfo.Arguments = fileName;
                myProcess.StartInfo.CreateNoWindow = true;
                myProcess.EnableRaisingEvents = true;
                myProcess.Exited += new EventHandler(myProcess_Exited);
                myProcess.Start();
            }
            catch (Exception ex)
            {
                /* handle exceptions here */
                return;
            }
        }
        public bool finished()
        {
            return finishedFlag;
        }
        // handle exited event (process terminated)
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            finishedFlag = true;
        }
        public static void Main(string[] args)
        {
            ExampleClass example = new ExampleClass();
            example.ConvertVideo("my_video.avi");
            /* you should watch for when the finished method
               returns true, and then act accordingly */
            /* as we are in a console, the host application (we)
               may finish before the guest application (convert.exe),
               so we need to wait here */
            while(!example.finished()) {
                /* wait */
                Thread.Sleep(100);
            }
            /* video finished converting */
            doActionsAfterConversion();
        }
