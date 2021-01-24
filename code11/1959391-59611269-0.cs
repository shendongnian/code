    public interface Iterator<MA, A>
    {
        bool HasNext(MA iter);
        A Next(MA iter);
    }
