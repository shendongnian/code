    for(int i=0;i<gridview.rows.count-1;i++)
    {
     //some operation;
     if (!aFunction(param1,param2)) continue;
    }
    
    public bool aFunction(param1,param2)
    {
     //some operation;
    if (!Regex.IsMatch(RechargeText, "successfully"))
            {
                RechargeStatus = "Failed";
                Program.sp.SoundLocation =
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                    "/aimlife_error.wav";
                Program.sp.Play();
            }
            else if (Regex.IsMatch(RechargeText, "Processing") || Regex.IsMatch(RechargeText, "Not"))
            {
                Program.StatusMessage = "Recharge Successful";
                TextFill();
                return false;
                // here i need to skip the Loop
            }
            else
            {
                Program.sp.SoundLocation =
                    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) +
                    "/aimlife_success.wav";
                Program.sp.Play();
            }
            Program.StatusMessage = "Recharge Successful";
            TextFill();
            return true;
    }
