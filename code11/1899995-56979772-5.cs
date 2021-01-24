    public class MyService
    {
        public void UpdateData(Type dataType, Something data, Something otherData)
        {
            // do stuff
        }
        public void UpdateData<T>(Something data, Something otherData)
        {
            UpdateData(typeof(T), data, otherData);
        }
    }
