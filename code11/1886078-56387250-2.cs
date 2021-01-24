using System.Threading.Tasks;
[WebMethod] //WebServiceMethod
public string ImportaDadosPosLeilaoValores(string fileName)
{
    // this call may take several minutes and should NOT be expected
    Task.Run(() => {
        ImportaDados(fileName);
    }); 
    return "OK - Received";     // immediately
}
I'm not familiar with what [WebMethod] is from, but you may want to go full async. In this example, your calling and called methods are async, and the called task isn't awaited, this will execute how you want.
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
Tasks run on threads, and are executed by a scheduler that manages the sync state of each task. Don't use threads directly unless you have a specific reason to. 
