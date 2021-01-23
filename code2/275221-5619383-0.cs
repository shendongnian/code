        public string ErrorMessage
        {
          [MethodImplAttribute(MethodImplOptions.NoInlining)]
          set
            {
             _strErrorMessage = "Error : " + value;
             //Call the method to log error.
             LogError(value);
            }
        }
