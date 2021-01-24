csharp
TaikunCliCommand command;
do
{ 
    var userInput = Console.ReadLine();
    command = taikunCommandInterpreter.InterpretCommand(userInput);    
    switch (command.CommandType)
    {
        case CommandType.ListProjects:
            await Project.GetProjects();
            break;
        case CommandType.CreateProject:
            await CreateProject(command);       
        case CommandType.Invalid:
            Console.WriteLine("Please specify valid command");
            break;
    }
} while (command.CommandType != CommandType.Quit);
// ...
async Task CreateProject(TaikunCliCommand command)
{
    string projectName;
    string kubesprayVersion;
    if(command.HasProjectName)
    {
        projectName = command.ProjectName;
    }
    else
    {
        Console.WriteLine("Please specify project name");
        projectName = Console.ReadLine();
    }
    // basically the same for the kubespray version
    // ...
    await Project.Create(projectName, kubesprayVersion);
}
Or even better: Separate the logic whether the input shall be requested from requesting the input
csharp
TaikunProjectInfo CreateProjectInfoFromCliCommand(TaikunCliCommand command, 
                                                  Func<string> requestProjectName, 
                                                  Func<string> requestKubeVersion)
{
    string projectName;
    string kubesprayVersion;
    if(command.HasProjectName)
    {
        projectName = command.ProjectName;
    }
    else
    {
        projectName = requestProjectName();
    }
    // similar for the kubespray version
    return new TaikunProjectInfo(projectName, kubesprayVersion);
}
You can call this like 
var projectInfo = CreateProjectInfoFromCliCommand(command, RequestProjectName, RequestKubesprayVersion);
await Project.Create(projectInfo.Name, projectInfo.KubesprayVersion);
// ...
string RequestProjectName()
{
    Console.WriteLine("Please specify project name");
    return Console.ReadLine();
}
string RequestKubesprayVersion()
{
    Console.WriteLine("Please specify project kubespray version");
    return Console.ReadLine();
}
[1]: https://stackoverflow.com/a/60414320/2249175
