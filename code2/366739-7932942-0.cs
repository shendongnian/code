        ContentManager contentManager = new ContentManager();
        ContentCriteria criteria = new ContentCriteria();
        criteria.AddFilter(ContentProperty.FolderId,
                           CriteriaFilterOperator.EqualTo,
                           folderId);
        List<ContentData> list = contentManager.GetList(criteria);
        Listview1.DataSource = list;
        Listview1.DataBind();
