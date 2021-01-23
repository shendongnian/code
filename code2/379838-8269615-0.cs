    public static void DoBoth(Action first, Action second, bool keepOrder)
        {
            if (keepOrder)
            {
                first();
                second();
            }
            else
            {
                second();
                first();
            }
        }
