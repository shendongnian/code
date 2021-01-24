     public static Page ResolvePageModel(Type type, object data, FreshBasePageModel pageModel)
        {
            var name = PageModelMapper.GetPageTypeName(s);
            var pageType = Type.GetType(name);
            if (pageType == null)
                throw new Exception(name + " not found");
            var page = (Page)FreshIOC.Container.Resolve(pageType);
            BindingPageModel(data, page, pageModel);
            return page;
        }
