        void System.Collections.IList.Insert(int index, Object item) 
        {
            ThrowHelper.IfNullAndNullsAreIllegalThenThrow<T>(item, ExceptionArgument.item); 
 
            try {
                Insert(index, (T) item); 
            }
            catch (InvalidCastException) {
                ThrowHelper.ThrowWrongValueTypeArgumentException(item, typeof(T));
            } 
        }
