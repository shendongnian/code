public string FcName { get; private set; }
public Salida(string gdbName)
{
    //GeodatabaseManage gdbManageInput = new GeodatabaseManage(_inputGdbPath);
    //gdbName = _inputGdbPath;
    //_gdbName = gdbName.Substring(15);
    FcName = string.Format("PositionalAccuracySamplePoints_{0}", gdbName.Substring(15));
}
 
