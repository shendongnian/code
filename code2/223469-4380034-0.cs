        private Boolean IsCreated = false;
        
        private String myVar1;
        public String MyVar1
        {
           get { return myVar1; }
           set {
                  if (LicenseManager.UsageMode ==  LicenseUsageMode.Designtime 
                        || !IsCreated)
                  {
                      myVar1 = value;
                      IsCreated = true;
                  }
        }
