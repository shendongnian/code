    if (att != null)
    {
        Console.WriteLine("Method {0} will be tested; reps={1}; msg={2}; memo={3}", mi.Name, att.Repititions,
                            att.FailureMessage, att.Memo);
        for (int i = 0; i < att.Repititions; i++)
            try
            {
                mi.Invoke(new Foo(), null);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + att.FailureMessage, ex);
            }
    }
