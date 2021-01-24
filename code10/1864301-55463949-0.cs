    Milk nestedMilks = new Milk();
    for (int i = 1; i < nestedAmount; i++)
    {
        nestedMilks = new Milk(nestedMilks);
    }
    Coffee final = new Coffee(nestedMilks);
