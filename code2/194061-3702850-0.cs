        public static int SafeGetId(this Process process)
        {
            if (process == null) throw new ArgumentNullException("process");
            try
            {
                return process.Id;
            }
            catch (InvalidOperationException ex)
            {
                //Do special logic, such as wrap in a custom ProcessTerminatedException
                throw;
            }
        }
