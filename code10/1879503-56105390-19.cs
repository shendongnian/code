    private readonly Queue<Transform> _commands = new Queue<Transform>();
    public void SubmitName()
    {
        var lines = mainInputField.text.Split('\n');
        mainInputField.text = "";
        foreach (var line in lines)
        {
            switch (line)
            {
                case "UP":
                    // adds a new item to the end of the Queue
                    _commands.Enqueue(TargetUp);
                    break;
                case "DOWN":
                    _commands.Enqueue(TargetDown);
                    break;
                case "LEFT":
                    _commands.Enqueue(TargetLeft);
                    break;
                case "RIGHT":
                    _commands.Enqueue(TargetRight);
                    break;
            }
        }
        StartCoroutine(WorkCommands());
    }
    private IEnumerator WorkCommands()
    {
        // block input
        Click_me.interactable = false;
        // run this routine until all commands are handled
        while (_commands.Count > 0)
        {
            // returns the first element and at the same time removes it from the queue
            var target = _commands.Dequeue();
            // you can simply yield another IEnumerator
            // this makes it execute and at the same time waits until it finishes
            yield return MovementCoroutine(target);
        }
        // when done allow input again
        Click_me.interactable = true;
    }
