    public class MyService: IMyService
    {
        public BaseModel Get()
        {
            return new ChildModel();
        }
    }
