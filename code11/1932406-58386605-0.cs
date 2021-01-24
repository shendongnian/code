public static Try(string s, object ctrl ) // Change object to type of the controll you're using
            {
                try
                {
                    int i = Directory.GetFiles(s, "*.*", SearchOption.AllDirectories).Length;
                   ctrl.Text = i.ToString();
                }
                catch { ctrl.Text = "Device Dont Connected"; }
            }
-----
It's very good that you are trying to improve it as there is a bug in your code:
    try
    {
        int CONSdeviceE = Directory.GetFiles(@"E:\", "*.*", SearchOption.AllDirectories).Length;
        LBLUnidadD.Text = CONSdeviceE.ToString();  <-----------D
    }
    catch { LBLUnidadE.Text = "Device Dont Connected"; } <-----------E
