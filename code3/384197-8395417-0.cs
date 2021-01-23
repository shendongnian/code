    public void RunStep<T>(string stepName, Func<T> stepFunc)
        {
            Status("Start Step " + stepName);
            var result = stepFunc();
            Status("End Step " + stepName, result);
        }
