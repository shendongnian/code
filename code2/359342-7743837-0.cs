    List<Apple> apples = ...
    var selectableApples = apples.Select(a => new SelectableApple { SelectedByPerson = null, Apple = a });
    
    foreach (Person person in persons)
    {
        foreach (var unselectedApple in selectableApples.Where(aa => aa.SelectedByPerson == null))
        {
            // This will ideally give all apples to the first person who
            // meets the conditions. As such this if condition can be moved
            // out side of the above the foreach loop.
            if (/*the person satisfies some conditions*/)
            {
                // This gets executed like 100 times:
                unselectedApple.SelectedByPerson = person;
            }
        }
    }
    
    foreach (var selectedApple in selectableApples.Where(aa => aa.SelectedByPerson != null))
    {
        Unreachable code - the collection is empty... WTF???
    }
    
