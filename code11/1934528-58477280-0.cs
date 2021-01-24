    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\[([^\]]*)\]\s*(=|>=|<=)\s*(@\w+)";
            string substitution = @"[new_value] $2 $3";
            string input = @"select [System.Id], [System.WorkItemType], [System.Title], [System.AssignedTo], [System.State], [System.Tags] from WorkItems where [System.TeamProject] = @project and [Microsoft.VSTS.Common.ClosedDate] >= @startOfDay and [System.State] = 'Closed' and [Microsoft.VSTS.Common.ClosedDate] >= @startOfDay
    
    Note [System.State] = 'Closed' is not matched.";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
        }
    }
