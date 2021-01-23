    using System;
    using System.Management.Automation;
    
    namespace Einstein.PowerShell
    {
        
        public sealed class DynamicVariable : PSVariable
        {
        
            #region Constructors
        
            /// <summary>
            /// </summary>
            public DynamicVariable(string name, ScriptBlock onGet)
                : this(name, onGet, null)
            {
            }
            
            /// <summary>
            /// </summary>
            public DynamicVariable(string name, ScriptBlock onGet, ScriptBlock onSet)
                : base(name, null, ScopedItemOptions.AllScope)
            {
                OnGet = onGet;
                OnSet = onSet;
            }
    
            #endregion
            
            #region Properties
            
            /// <summary>
            /// The ScriptBlock that runs to get the value of the variable.
            /// </summary>
            private ScriptBlock OnGet
            {
                get;
                set;
            }
            
            /// <summary>
            /// The ScriptBlock that runs to get the value of the variable.
            /// </summary>
            private ScriptBlock OnSet
            {
                get;
                set;
            }
            
            /// <summary>
            /// Gets or sets the underlying value of the variable.
            /// </summary>
            public override object Value
            {
                get
                {
                    if (OnGet == null) {
                        return null;
                    }
                    return OnGet.Invoke();
                }
                set
                {
                    if (OnSet == null) {
                        throw new InvalidOperationException("The variable is read-only.");
                    }
                    OnSet.Invoke(value);
                }
            }
            
            #endregion
            
        }
        
    }
