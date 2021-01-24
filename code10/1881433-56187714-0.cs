using System.Web.Http; 
public JsonResult Edit([FromBody]List<Ocorrencia> ocorrencia,HttpPostedFileBase logo)
{
}
**Edited**
`using System.Web.Http` can be added by Microsoft.AspNet.WebApi.Core package on NuGet.
