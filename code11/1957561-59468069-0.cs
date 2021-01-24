    @if (issues == null)
        {
            <p><em>Loading...</em></p>
        }
        else
        {
            <table class="table">
                <thead>
                    <tr>
                        <th>Name</th>
                        <th>Resolution</th>
                    </tr>
                </thead>
                <tbody>
                    @foreach (var client in issues)
                    {
                        <tr>
                            <td>@client.Name</td>
                            <td>@client.Resolution</td>
                        </tr>
                    }
                </tbody>
            </table>
        }
    
    
    <input type="text" @bind-value="@searchTerm" />
    <input type="button" value="Search" @onclick="@SearchIssues"/>
    
    @code {
    private string searchTerm;
    private List<Issue> issues;
    
        async Task SearchIssues()
        {
            issues= await issuesController.SearchIssuesAsync(searchTerm);
        }
    }
  
