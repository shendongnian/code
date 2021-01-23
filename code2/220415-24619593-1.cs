    public class NotifyPropertyChangedBehavior : IInterceptionBehavior
    {
    ...
        public IMethodReturn Invoke(IMethodInvocation input, GetNextInterceptionBehaviorDelegate getNext)
        {
            if (input.MethodBase.Name.Equals(addEventMethodInfo.Name))//(input.MethodBase == addEventMethodInfo)
            {
                return AddEventSubscription(input, getNext);
            }
            if (input.MethodBase.Name.Equals(removeEventMethodInfo.Name))//(input.MethodBase == removeEventMethodInfo)
            {
                return RemoveEventSubscription(input, getNext);
            }
            if (IsPropertySetter(input))
            {
                return InterceptPropertySet(input, getNext);
            }
            return getNext()(input, getNext);
        }
    ...
    }
