c#
public HttpResponseMessage SerialPortList()
{
    return SerialPortList(SerialPort.GetPortNames);
}
public HttpResponseMessage SerialPortList(Func<string[]> getPortNames)
{
    HttpResponseMessage response;
    try
    {
        List<string> Ports = new List<string>(getPortNames());
        response = Request.CreateResponse(HttpStatusCode.OK, Ports);
    }
    catch (Exception ex)
    {
        response = Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
    }
    return response;
}
in your unit test...
c#
public void Test()
{
    var portNames = new[] { "COM1" };
    foo.SerialPortList(() => portNames);
}
