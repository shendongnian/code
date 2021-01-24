public static void Try(string s, object ctrl ) // Change object to type of the controll you're using
{
    try
    {
        int i = Directory.GetFiles(s, "*.*", SearchOption.AllDirectories).Length;
        ctrl.Text = i.ToString();
    }
    catch { ctrl.Text = "Device Dont Connected"; }
}
(...)
Try(@"D:\", LBLUnidadD);
Try(@"E:\", LBLUnidadE);
Try(@"F:\", LBLUnidadF);
-----
It's very good that you are trying to improve it as there is a bug in your code:
    try
    {
        int CONSdeviceE = Directory.GetFiles(@"E:\", "*.*", SearchOption.AllDirectories).Length;
        LBLUnidadD.Text = CONSdeviceE.ToString();  <-----------D
    }
    catch { LBLUnidadE.Text = "Device Dont Connected"; } <-----------E
---- 
----
#With some reflection magic
I never recommend using reflection in real systems but here's a version for fun
Try(new { LBLUnidadD });
Try(new { LBLUnidadE });
Try(new { LBLUnidadF });
}
public static void Try<T>(T ctrl ) where T: class
{
	var p = typeof(T).GetProperties()[0];
	var o = (A)(object)p.GetValue(ctrl);// Change A to what LBLUnidadD is (Is it 'Label'?)
	try
	{
		var driveLetter = p.Name.Last();
		int i = Directory.GetFiles(driveLetter+@":\", "*.*", SearchOption.AllDirectories).Length;
		o.Text = i.ToString();
	}
	catch { o.Text = "Device Dont Connected"; }
}
