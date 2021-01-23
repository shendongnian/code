        public interface ILogFactory
        {
            #region Public Methods and Operators
     
            /// <summary>
            ///     Creates a logger with the Callsite of the given Type
            /// </summary>
            /// <example>
            ///     factory.Create(GetType());
            /// </example>
            /// <param name="type">The type.</param>
            /// <returns></returns>
            ILogger Create(Type type);
     
            #endregion
        }
