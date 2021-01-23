            List<Thread> ThreadsPerOneRecord = new List<Thread>();
            bool ExecuteSingleThreaded = false;
            //The variable list is passed as parameter to the function  
            foreach (Record prov in list)
            {
                var tempProv = prov;
                XMLResult.AppendText("Type: " + prov.Type + Environment.NewLine);
                Thread t = new Thread(() => Send(tempProv, c));
                t.Start();
                //Here the sleep  
                Thread.Sleep(50);
                ThreadsPerOneRecord.Add(t);
                #region Code for test single threaded execution
                if (ExecuteSingleThreaded)
                {
                    foreach (Thread t2 in ThreadsPerOneRecord)
                        t2.Join();
                    ThreadsPerOneRecord.Clear();
                }
                #endregion
            }
            XMLResult.AppendText("Waiting for the threads to finish" + Environment.NewLine);
            //Waiting for the threads to finish 
            foreach (Thread t in ThreadsPerOneRecord)
                t.Join(); 
