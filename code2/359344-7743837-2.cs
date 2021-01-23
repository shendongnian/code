    List<Apple> apples = ...
    var selectableApples = apples.Select(a => new SelectableApple { SelectedByPerson = null, Apple = a }); 
    var selectedPerson = persons.Where(p => /*the person satisfies some conditions*/).First()
    if(selectedPerson != null)
    {
        foreach (var unselectedApple in selectableApples.Where(aa => aa.SelectedByPerson == null))
        {
            // This gets executed like 100 times:
            unselectedApple.SelectedByPerson = person;
        }
    }
    
    foreach (var selectedApple in selectableApples.Where(aa => aa.SelectedByPerson != null))
    {
        Unreachable code - the collection is empty... WTF???
    }
