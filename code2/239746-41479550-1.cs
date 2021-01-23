     public class Test
     {
        protected Action _actionRequired;
        public event Action ActionRequired {
            add {
                _actionRequired += value;
            }
            remove {
                _actionRequired += value;
            }
        }
     }
    public class ChildTest : Test
    {
        public void DoSomething()
        {
            if (this._actionRequired != null)
                this._actionRequired();
        }
    }
