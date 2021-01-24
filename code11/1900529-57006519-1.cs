static void Main(string[] args)
{
    //For TFS :
    var tfsUrl = "http://[serername]:[port]/[tfs]/[name]";
    var buildClient = new BuildHttpClient(new Uri(tfsUrl), new VssAadCredential());
    var definitions = buildClient.GetFullDefinitionsAsync(project: "Projects");
    foreach (var definition in definitions.Result)
    {
        Console.WriteLine($"Check {definition.Id} - {definition.Name}...");
        foreach (var phase in ((Microsoft.TeamFoundation.Build.WebApi.DesignerProcess)definition.Process).Phases)
        {
            foreach (var step in phase.Steps)
            {
                var handler = new HttpClientHandler();
                handler.UseDefaultCredentials = true;
                var client = new HttpClient(handler);
                client.BaseAddress = new Uri(tfsUrl);
                var response = client.GetAsync($"_apis/distributedTask/tasks/{step.TaskDefinition.Id}").Result;
                var jsonResponse = response.Content.ReadAsStringAsync().Result;
                dynamic d = JObject.Parse(jsonResponse);
                if (d.Result != null && d.value[0].deprecated == true)
                {
                    Console.WriteLine($"'{step.DisplayName}' is deprecated");
                }
            }
        }
    }
    Console.WriteLine("Press any key to continue..");
    Console.ReadLine();
}
