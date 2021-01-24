        uc_WorkingArea gc = new uc_WorkingArea();
        for (int i = 0; i < 10; i++) //PASS SOME TIME
        {
            Application.DoEvents(); //CONSOLE SHOULD SPAM 'RUN' FROM TASK
            Thread.Sleep(1);
        }
        gc.cts.Cancel(); //CANCEL CALL, WHILE LOOP END
        if (gc.token.IsCancellationRequested)
        {
            Console.WriteLine("stop");
            MessageBox.Show("Canceled requested");
        }
        gc.cts.Dispose();
        gc.Printer1.Dispose();
