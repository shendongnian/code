using System.Threading.Tasks;
[WebMethod] //WebServiceMethod
public string ImportaDadosPosLeilaoValores(string fileName)
{
    // this call may take several minutes and should NOT be expected
    Task.Run(async () => {
        ImportaDados(fileName);
    }); 
    return "OK - Received";     // immediately
}
I'm not familiar with what [WebMethod] is from, but you may want to go full async.
using System.Threading.Tasks;
[WebMethod] //WebServiceMethod
public async Task<string> ImportaDadosPosLeilaoValores(string fileName)
{
    // this call may take several minutes and should NOT be expected
    ImportaDados(fileName);
    return "OK - Received";     // immediately
}
public async Task ImportaDados(string filename)
{
}
