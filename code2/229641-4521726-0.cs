    void Interact<TA, TB>(TA objectA, TB objectB)
    {
        var interact = Container.Resolve<IInteract<TA, TB>>();
        interact.Interact(objectA, objectB);
    }
