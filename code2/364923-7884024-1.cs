    public sealed class DebugModel : IModel
    {
        private IModel _child;
        public DebugModel(IModel child)
        {
            this._child = child;
        }
        public void DoSomething(string aParm, int anotherParm)
        {
            // debug code before *actual* call
            _child.DoSomething(aParm, anotherParm);
            // debug code post-processing
        }
        public bool TryDoSomeOtherThing(int aParm, double aTolerance)
        {
            // same thing, debug before and after
            var ret = _child.TryDoSomeOtherThing(aParm, aTolerance);
            // maybe muck with ret?
            return ret;
        }
    }
