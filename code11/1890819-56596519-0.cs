c#
myGridView.InitRegistrator<Job>()
   .RegisterRule(column1, x => string.IsNullOrEmpty(x.Code))
   .RegisterRule(column2, x => string.IsNullOrEmpty(x.Name))
**MyGridView**
c#
public class MyGridView : GridView
{
   internal ErrorRegistrator ErrorRegistrator = new ErrorRegistrator();
   public GenericErrorRegistrator<T> InitRegistrator<T>(params Func<T, bool>[] funcs)
   {
      return ErrorRegistrator.Init<T>();
   }
}
**ErrorRegistrator**
c#
    internal class ErrorRegistrator
    {
        internal bool HasRules => _registrator.HasRules();
        private BaseGenericErrorRegistrator _registrator;
        internal GenericErrorRegistrator<T> Init<T>()
        {
            var errorRegistrator = new GenericErrorRegistrator<T>();
            _registrator = errorRegistrator;
            return errorRegistrator;
        }
        public bool CheckRule(string columnName, object row)
        {
            return _registrator.CheckRule(columnName, row);
        }
    }
    public abstract class BaseGenericErrorRegistrator
    {
        internal abstract bool HasRules();
        internal abstract bool CheckRule(string columnName, object row);
    }
    public class GenericErrorRegistrator<T> : BaseGenericErrorRegistrator
    {
        private readonly Dictionary<string, Func<T, bool>> _rules = new Dictionary<string, Func<T, bool>>();
        public GenericErrorRegistrator<T> RegisterRule(string columnName, Func<T, bool> func)
        {
            _rules.Add(columnName, func);
            return this;
        }
        internal override bool HasRules()
        {
            return _rules.Any();
        }
        internal override bool CheckRule(string columnName, object row)
        {
            return _rules.TryGetValue(columnName, out Func<T, bool> func) && func((T) row);
        }
    }
Then I can use `ErrorRegistrator` field to check rules
