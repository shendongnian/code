    public class YourViewModel
    {
            public virtual ObservableCollection<YourComplexType> YourCollection
            {
                get
                {
                    var list = new ObservableCollection<YourComplexType>(YourStaticClass.YourList);
                    var allEntity = new YourComplexType();
                    allEntity.Name = "all";
                    allEntity.Id = 0;
                    list.Insert(0, allEntity);
                    return list;
                }
            }
    }
