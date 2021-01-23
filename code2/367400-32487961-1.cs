    public partial class MyEntity
    {
        protected MyEntity()
        {
            // This makes the entities connected though, this instance of MyEntity will be deleted afterwards, the instance of MyEntityResult will not.
            MyEntityResult = new MyEntityResult(this);
        }
    }
