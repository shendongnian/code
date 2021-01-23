    public class Foo
    {
        private IInterface1 _object; // just pick one
        public void setObject<T>(T obj)
            where T : IInterface1, IComparable<T>, IEtcetera
        {
            // you now *know* that object supports all the interfaces
            // you don't need the compiler to remind you
            _object = obj; 
        }
        public void ExerciseObject()
        { 
            // completely safe due to the constraints on setObject<T>
            IEtcetera itf = (IEtcetera) _object;
            // ....
        }
