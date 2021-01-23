    new System.Threading.Thread(new System.Threading.ThreadStart(delegate() 
        {
            foreach (DataRow _dr in _allDt.Rows)
            {
                //check if machine is online out of 100 machines list using async approach
                if (_connectionUtil.ConnectionIsOn(_dr["ipAddress"].ToString()))
                    _onMachineAl.Add(_machineInfo);
                this._progressBar.Invoke(new MethodInvoker(delegate() // Invoke you need for accessing the UI thread and controls
                { 
                    _progressBar.PerformStep();
                }));
            }
        })).Start();
