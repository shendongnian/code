    DateTime begin = new DateTime(2011, 03, 07);
    TimeSpan timeSpan = DateTime.Now - begin;
    switch (((int) timeSpan.TotalDays / 7) % 3)
    {
        case 0:
            break;
        case 1:
            break;
        case 2:
            break;
        default:
            throw new Exception();
    }
