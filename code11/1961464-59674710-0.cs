    public class MyPageModelMapper : IFreshPageModelMapper
        {
            public string GetPageTypeName(Type pageModelType)
            {
                var mainpagemodel = typeof(MainPageModel);
                var s = Type.GetType(mainpagemodel.AssemblyQualifiedName);
                var mainviewmodel = typeof(MainViewModel);
                var s2 = Type.GetType(mainviewmodel.AssemblyQualifiedName);
                return pageModelType.AssemblyQualifiedName
                    .Replace("PageModel", "Page")
                 .Replace("ViewModel", "Page");
            }
        }
