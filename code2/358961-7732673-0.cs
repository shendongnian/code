        // implements `IEquatable` for a list of parameters
        class Parameters : IEquatable<Parameters>
        {
            private readonly object[] _parameters;
            public Parameters(object[] parms)
            {
                _parameters = parms;
            }
            #region IEquatable<Parameters> Members
            public bool Equals(Parameters other)
            {
                if (other == null)
                    return false;
                if (_parameters.Length != other._parameters.Length)
                    return false;
                // check each parameter to see if it's equal
                // ...     
            }
            public override bool Equals(object obj)
            {
                return Equals(obj as Parameters);
            }
            public override int GetHashCode()
            { ... }
            #endregion
        }
    
