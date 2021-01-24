 c#
[HttpGet]
[Route("newProjectList")]
public string NewProjectList()
{
    string str;
    ModelProjectClass d = new ModelProjectClass();
    str = d.NewProject();
    return str;
}
