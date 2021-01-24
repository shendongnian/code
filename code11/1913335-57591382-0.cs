var vm = new MyViewModel();
vm.GroupPlans = allWorkPlan.GroupBy(p => p.PlanNumber)
					.Select(p => new GroupPlan { PlanNumber = p.Key, Day = p.GroupBy(b => b.Day).ToList() }).ToList();
GroupPlan Class
public class GroupPlan
{
	public int PlanNumber { get; set; }
	public List<IGrouping<string, WorkPlan>> Day { get; set; }
}
ViewModel Class
public class MyViewModel
{
	public List<GroupPlan> GroupPlans { get; set; }	
}
