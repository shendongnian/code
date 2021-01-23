         private static Mutex mutex = null;
         private void CheckIfRunning() {
           string strId = "291B62B2-812A-4a13-A657-BA672DD0C93B";
            bool bCreated;
            try
            {
                mutex = new Mutex(false, strId, out bCreated);
            }
            catch (Exception)
            {
                bCreated = false;
                //Todo: Kill your process
            }
            if (!bCreated)
            {
                MessageBox.Show(Resources.lbliLinkAlreadyOpen, Resources.lblError,         MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
          }
