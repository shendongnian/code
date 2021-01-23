    public interface IDirtyObject
    {
        /// <summary>Gets a value indicating whether this object is dirty.</summary>
        bool IsDirty { get; set; }   // or perhaps get only?
        /// <summary>Sets this object, as well as dirty objects within it, to
        /// the specified dirty value.</summary>
        void SetAllDirty(bool dirty);
    }
