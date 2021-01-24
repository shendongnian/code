var group = result.GroupBy(g => new { DateTime.Parse(g.CreationDate).Date.Month, g.AccountType })
                  .Select(user => new { user.Key.AccountType, user.Key.Month, Count = user.Count() });
foreach (var g in group)
{
    Console.WriteLine($"Users with Month[{g.Month}] : {g.Count}, AccType: {g.AccountType};");
}
