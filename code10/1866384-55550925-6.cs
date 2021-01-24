    using Microsoft.VisualStudio.Services.WebApi;
    using System;
    using System.Linq;
    using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Clients;
    using Microsoft.VisualStudio.Services.ReleaseManagement.WebApi.Contracts;
    using Microsoft.VisualStudio.Services.Common;
    using System.Collections.Generic;
    
    namespace FindReleaseByAgentPoolID
    {
        class Program
        {
            const int agentPoolID = 999;
            static void Main(string[] args)
            {
                var relevantReleases = new List<string>();
                VssCredentials c = new VssCredentials(new WindowsCredential(System.Net.CredentialCache.DefaultNetworkCredentials));
                var tfsURL = new Uri("TFS URL");
                var teamProjectName = "PROJECT";
    
                using (var connection = new VssConnection(tfsURL, c))
                using (var rmClient = connection.GetClient<ReleaseHttpClient2>())
                {
                    var releases = rmClient
                        .GetReleaseDefinitionsAsync(teamProjectName, string.Empty, ReleaseDefinitionExpands.Environments)
                        .Result.ToArray();
    
                    foreach (var release in releases)
                    {
                        var r = rmClient.GetReleaseDefinitionAsync(teamProjectName, release.Id);
                        var deploymentAgents = r.Result.Environments.SelectMany(e =>
                         e.DeployPhases.Select(dp =>
                         dp.GetDeploymentInput()).Cast<DeploymentInput>()).Where(di =>
                         di.QueueId == agentPoolID).Count();
    
                        if (deploymentAgents > 0)
                        {
                            relevantReleases.Add(release.Name);
                        }
                    }
                }
            }
        }
    }
