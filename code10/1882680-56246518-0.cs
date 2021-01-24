c#
[HttpGet]
[Route("PortList")]
public HttpResponseMessage SerialPortList()
{
    return SerialPortList(SerialPort.GetPortNames());
}
public HttpResponseMessage SerialPortList(string[] portNames)
{
    HttpResponseMessage response;
    try
    {
        List<string> Ports = new List<string>(portNames);
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
[Fact]
public void Test()
{
    var portNames = new[] { "COM1" };
    foo.SerialPortList(portNames);
}
