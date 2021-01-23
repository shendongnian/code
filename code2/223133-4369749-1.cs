      static void Main()
      {
         string mutex_id = "MY_APP";
         using (Mutex mutex = new Mutex(false, mutex_id))
         {
            if (!mutex.WaitOne(0, false))
            {
               MessageBox.Show("Instance Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
               return;
            }
            // Do stuff
         }
      }
