    protected override void OnStart(string[] args)
            {
                try
                {
                    RequestAdditionalTime(600000);
                    Debugger.Launch(); // put brake point here.
                   ............. your code 
                }
                catch (Exception ex)
                {
                    ......... your exception code
                }
            }
