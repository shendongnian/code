public class MyModelVm
{
    public HttpStatusCode StatusCode { get; set; }
}
Index.cshtml
@model MyNamespace.MyModelVm
@functions
{
    string GetErrorMessage()
    {
        var isNotFound = Model.StatusCode == HttpStatusCode.NotFound;
        string errorMessage;
        if (isNotFound)
        {
            errorMessage = Resources.NotFoundMessage;
        }
        else
        {
            errorMessage = Resources.GeneralErrorMessage
        }
        return errorMessage;
    }
}
<div>
    @GetErrorMessage()
</div>
