    @model TestJira.Models.Jira
        @for (var i = 0; i < Model.Issues.Count; i++)
        {
            <div>
                Model.Issues[i].Summary
            </div>
        }
