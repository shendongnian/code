      static void Main()
      {
         string mutex_id = "MY_APP";
         using (NamedMutex mutex = new NamedMutex(false, mutex_id))
         {
            if (!mutex.WaitOne(0, false))
            {
               MessageBox.Show("Instance Already Running!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
               return;
            }
            // Do stuff
         }
      }
