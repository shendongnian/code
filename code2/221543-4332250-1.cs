    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    using System.Threading;
    class ConverterClass
    {
        private Process myProcess = new Process();
        private bool finishedFlag = false;
        /* converts a video asynchronously */
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
        /* handle exited event (process closed) */
        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            finishedFlag = true;
        }
        public static void Main(string[] args)
        {
            ConverterClass converter = new ConverterClass();
            converter.ConvertVideo("my_video.avi");
            /* you should watch for when the finished method
               returns true, and then act accordingly */
            /* as we are in a console, the host application (we)
               may finish before the guest application (convert.exe),
               so we need to wait here */
            while(!converter.finished()) {
                /* wait */
                Thread.Sleep(100);
            }
            /* video finished converting */
            doActionsAfterConversion();
        }
    }
