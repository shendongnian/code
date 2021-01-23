    public partial class Database1Entities
    {
        partial void OnContextCreated()
        {
            this.ObjectMaterialized += (_, e) =>
            {
                try
                {
                    dynamic entity = e.Entity;
                    entity.ObjectContext = this;
                }
                catch (RuntimeBinderException)
                {
                }
            };
            this.ObjectStateManager.ObjectStateManagerChanged += (_, e) =>
            {
                if (e.Action == CollectionChangeAction.Add)
                {
                    try
                    {
                        dynamic entity = e.Element;
                        entity.ObjectContext = this;
                    }
                    catch (RuntimeBinderException)
                    {
                    }
                }
                else if (e.Action == CollectionChangeAction.Remove)
                {
                    try
                    {
                        dynamic entity = e.Element;
                        entity.ObjectContext = null;
                    }
                    catch (RuntimeBinderException)
                    {
                    }
                }
            };
        }
    }
