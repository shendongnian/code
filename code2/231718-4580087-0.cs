    public void MyMethod(Somestatus status)
    {
        foreach (Action toDo in new Action[] { DoA, DoB, DoC, DoD, DoE }.Take(5 - (int)status))
            toDo();
    }
