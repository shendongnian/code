var plans = await graphServiceClient
    .Me
    .Planner
    .Plans
    .Request()
    .GetAsync();
foreach (var plan in plans)
{
    Console.WriteLine($"{plan.Title} ({plan.Id})");
    var tasks = await graphServiceClient
        .Planner
        .Plans[plan.Id]
        .Tasks
        .Request()
        .GetAsync();
    foreach (var task in tasks)
    {
        Console.WriteLine($"{task.Title} ({task.Id})");
    }
}
