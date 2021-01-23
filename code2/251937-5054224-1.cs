        private void ThreadSafeFunction(int intVal, bool boolVal)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(
                    new MethodInvoker(
                    delegate() { ThreadSafeFunction(intVal, boolVal); }));
            }
            else
            {
                //use intval and boolval
            }
        }   
