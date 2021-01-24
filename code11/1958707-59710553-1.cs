    public class Controller<T> : Controller where T : struct, System.IConvertible
    {
        public bool this[T enumIndex]
        {
            get { return actionStates[System.Convert.ToInt32(enumIndex)]; }
            set { actionStates[System.Convert.ToInt32(enumIndex)] = value; }
        }
    }
