class BudgetRequest {
    public int[] LevelNodeIds {get; set;}
}
(...)
var budgetRequest = new BudgetRequest() 
{
    LevelNodeIds = new int[OrgPath.Count]
};
for(int i = 0; i < OrgPath.Count; i++) {
    budgetRequest.LevelNodeIds[i] = OrgPath[i].LevelNodeId;
}
# Note on indexes
C#'s collections use indexing starting from 0. 
switch (OrgPath.Count)
{
    case 1:
        budgetRequest.Level1NodeId = OrgPath[1].LevelNodeId;
may need to be changed to 
switch (OrgPath.Count)
{
    case 1:
        budgetRequest.Level1NodeId = OrgPath[0].LevelNodeId;
