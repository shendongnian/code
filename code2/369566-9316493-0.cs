       public static IEnumerable IListFind(IEnumerable list, ConditionHandler handler, EventHandler errorHandler = null, DateTime? started = null)
        {
            try
            {
                if (started == null) { started = DateTime.Now; };
                return IListFindInternal(list, handler);
            }
            catch
            {
                if (DateTime.Now.Subtract(started.Value).TotalSeconds < 30)
                {
                    if (errorHandler != null) { errorHandler(list, EventArgs.Empty); };
                    return IListFind(list, handler, errorHandler, started);
                }
                else
                {
                    return null;
                }
            }
        }
        public static IEnumerable IListFindInternal(IEnumerable list, ConditionHandler handler) { foreach (object item in list) { if (handler(item)) { yield return item; } } }
