        var startOtherProcess = true;
        while (startOtherProcess) {
           var watchedProcess = Process.Start("MyProgram.Exe");
           watchedProcess.WaitForExit();
           if (testIfProcessingFinished) {
               startOtherProcess = false;
           }
          
        }
