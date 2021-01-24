    /// <summary>
    /// Interface to make values strongly-typed with help of TypeConverters.
    /// </summary>
    /// <typeparam name="TInnerType">Inner type</typeparam>
    public interface IStronglyTyped<out TInnerType>
    {
        /// <summary>
        /// Inner value.
        /// </summary>
        TInnerType Value { get; }
    }
