    void MethodA()
    {
        if (someCondition)
        {
            bool conditionReached = false;
            Monitor.Enter(this);
            try
            {
                if (someCondition)
                {
                    conditionReached = true;
                }
            }
            finally
            {
                Monitor.Exit(this);
            }
            if (conditionReached)
            {
                MethodB();
            }
        }
    }
