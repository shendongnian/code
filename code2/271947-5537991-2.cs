    interface ITitleDAL
    {
        TitleEntity InsertTitle(TitleEntity titleEntity);
        ICollection<TitleEntity> GetAllTitles();
    }
