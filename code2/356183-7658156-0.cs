    <?xml version="1.0" encoding="utf-8"?>
    <WorkItemQuery Version="1">
      <TeamFoundationServer>
      http://****>
      <TeamProject>****</TeamProject>
      <Wiql>SELECT [System.Id], [System.WorkItemType], [System.Title],
      [System.State], [System.AssignedTo],
      [Microsoft.VSTS.Scheduling.RemainingWork],
      [Microsoft.VSTS.Scheduling.CompletedWork],
      [Microsoft.VSTS.Scheduling.StoryPoints],
      [Microsoft.VSTS.Common.StackRank],
      [Microsoft.VSTS.Common.Priority],
      [Microsoft.VSTS.Common.Activity], [System.IterationPath],
      [System.AreaPath] FROM WorkItemLinks WHERE
      (Source.[System.TeamProject] = @project and
      Source.[System.AreaPath] under @project and
      Source.[System.IterationPath] under '****\Iteration 1' and
      (Source.[System.WorkItemType] = 'User Story' or
      Source.[System.WorkItemType] = 'Task')) and
      [System.Links.LinkType] = 'System.LinkTypes.Hierarchy-Forward'
      and Target.[System.WorkItemType] = 'Task' ORDER BY
      [Microsoft.VSTS.Common.StackRank],
      [Microsoft.VSTS.Common.Priority] mode(Recursive)</Wiql>
    </WorkItemQuery>
