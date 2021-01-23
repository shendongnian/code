    List<Apple> apples = ...
    var selectableApples = apples.Select(a => new SelectableApple { SelectedByPerson = null, Apple = a });
    
    foreach (Person person in persons)
    {
        // Now we can see that since this will all apples to the first person
        // who satisfies the below conditions we are still doing to much. And it
        // still does not work.
        if (/*the person satisfies some conditions*/)
        {
            foreach (var unselectedApple in selectableApples.Where(aa => aa.SelectedByPerson == null))
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
