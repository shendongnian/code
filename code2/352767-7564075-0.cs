    public static Mutex _myMutex = new Mutex(false, @"Global\SomeUniqueName");
    public ActionResult CreateNewApplication()
    {
        if (_myMutex.WaitOne(TimeSpan.Zero))
        {
            // DO WORK... RUN CODE
            _myMutex.ReleaseMutex();
            return View("Index", model);
        }
        else
        {
            // DISPLAY A MESSAGE THAT ANOTHER REQUEST IS IN PROCESS
        }
    }
