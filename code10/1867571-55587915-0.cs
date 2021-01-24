    public object GetValue(ContentType type)
    {
        switch (type)
        {
            case ContentType.BaseUri:
                return item.BaseUri;
                break;
            case ContentType.Categories:
                return item.Categories;
                break;
            case ContentType.Content:
                return item.Content;
                break;
            case ContentType.Contributors:
                return item.Contributors;
                break;
            case ContentType.Copyright:
                return item.Copyright;
                break;
          }
    }
