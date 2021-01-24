    foreach (var group in list.GroupBy(x => x.Key))
    {
        switch (group.Key) 
        {
            case 1:
                foreach (var item in group)
                {
                    Action1(item);
                }
                break;
            case 2:
                foreach (var item in group)
                {
                    Action2(item);
                }
                break;
            case 3:
                foreach (var item in group)
                {
                    Action3(item);
                }
                break;
            default:
                throw new Exception("Unexpected Group");
        }
    }
