    public interface IResult
    {
        Object Result { get; }
    }
    public interface IModel : IResult
    {
        Object A { get; }
        Object B { get; }
    }
    public class Model<T> : IModel
    {
        public T A { get; set; }
        public T B { get; set; }
        public T Result { get; set; }
        //  The "IModel.*" prefix means this is an "explicit" implementation of the IModel 
        //  interface. That means that ordinarily, model.A gets you the above strongly typed
        //  A property, but with an explicit cast to IModel, you get the non-generic IModel 
        //  version: model.A is int or whatever T is; ((IModel)model).A is object. 
        //
        //  These getters don't recurse because this is of type Model<T>, not IModel.
        //  If T is List<String>, a subclass could override this to return 
        //  String.Join(", ", Result);
        Object IModel.A => A;
        Object IModel.B => B;
        Object IResult.Result => Result;
    }
    public interface IAddHandler<T> where T : IModel
    {
        T Model { get; set; }
        T Add();
        void GetData();
    }
    public class IntegerHandler : IAddHandler<Model<int>>
    {
        public Model<int> Model { get; set; }
        public void GetData()
        {
            // Get Info to Add from external file for example
            Model = new Model<int> { A = 10, B = 20 };
        }
        public Model<int> Add()
        {
            Model.Result = Model.A + Model.B;
            return Model;
        }
    }
    public class StringHandler : IAddHandler<Model<string>>
    {
        public Model<string> Model { get; set; }
        public void GetData()
        {
            // Get Info to Add from external file for example
            Model = new Model<string> { A = "10", B = "20" };
        }
        public Model<string> Add()
        {
            Model.Result = Model.A + Model.B;
            return Model;
        }
    }
