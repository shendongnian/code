using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
namespace CodeWriter.Collections.Generic
{
    /// <summary>
    /// This represents a strongly typed list of objects that can be accessed by index. Provides methods to search, sort and manipulate the list.
    /// This class serves as a wrapper for a <see cref="List{T}"/>.  The internal class can be reached by the <see cref="SourceList"/> property.
    /// The elements that this class exposes from the <see cref="SourceList"/> can be controlled by changing the <see cref="Filter"/> property.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <remarks>
    /// This class was created to support situations where the functionality of two or more <see cref="List{T}"/> collections are needed where one is the Master Collection
    /// and the others are Partial Collections.  The Master Collection is a <see cref="List{T}"/> and exposes all elements in the collection.  The Partial Collections 
    /// are <see cref="FilteredList{T}"/> classes (this class) and only expose the elements chosen by the <see cref="FilteredList{T}"/> property of this class.  When elements are modified,
    /// in either type of collection, the changes show up in the other collections because in the backend they are the same list.  When elements are added or deleted from the Partial Collections,
    /// they will disappear from the Master Collection.  When elements are deleted from the Master Collection, they will not be available in the Partial Collection but it 
    /// may not be apparent because the <see cref="Filter"/> property may not be exposing them.
    /// </remarks>
    public class FilteredList<T> : IList<T>, ICollection<T>, IEnumerable<T>, IEnumerable, IList, ICollection, IReadOnlyList<T>, IReadOnlyCollection<T>
    {
        #region Public Constructor
        public FilteredList(List<T> SourceList)
        {
            if (SourceList == null)
            {
                throw new ArgumentNullException("SourceList");
            }
            _SourceList = SourceList;
        }
        public FilteredList()
        {
            _SourceList = new List<T>();
        }
        public FilteredList(IEnumerable<T> Collection)
        {
            if (Collection == null)
            {
                throw new ArgumentNullException("Collection");
            }
            _SourceList = new List<T>(Collection);
        }
        #endregion
        #region Protected Members
        protected List<T> _SourceList;
        protected Func<T, bool> _Filter;
        #endregion
        #region Public Properties
        #region Source List Properties
        /// <summary>
        /// Gets or sets the base class that this class is a wrapper around.
        /// </summary>
        public List<T> SourceList
        {
            get
            {
                return _SourceList;
            }
            set
            {
                _SourceList = value;
            }
        }
        /// <summary>
        /// Gets or sets the value used to filter the <see cref="SourceList"/>.
        /// </summary>
        public Func<T, bool> Filter
        {
            get
            {
                return _Filter;
            }
            set
            {
                _Filter = value;
            }
        }
        #endregion
        #region Normal List<T> Implementation
        /// <summary>
        /// Provides access to the collection the in the same manner as an <see cref="Array"/>.
        /// </summary>
        /// <param name="Index">The Index of the element you want to retrieve.  Valid values are from zero to the value in the <see cref="Count"/> property.</param>
        /// <returns>The element at the position provided with the indexer.</returns>
        public T this[int Index]
        {
            get
            {
                List<T> Selected = _SourceList.Where(_Filter).ToList();
                return Selected[Index];
            }
            set
            {
                List<T> Selected = _SourceList.Where(_Filter).ToList();
                Selected[Index] = value;
            }
        }
        /// <summary>
        /// Provides access to the collection the in the same manner as an <see cref="Array"/>.
        /// </summary>
        /// <param name="Index">The Index of the element you want to retrieve.  Valid values are from zero to the value in the <see cref="Count"/> property.</param>
        /// <returns>The element at the position provided with the indexer.</returns>
        /// <remarks>This is required for IList implementation.</remarks>
        object IList.this[int Index]
        {
            get
            {
                return this[Index];
            }
            set
            {
                if ((value is T) == false)
                {
                    throw new ArgumentException("Value passed is not a valid type.");
                }
                this[Index] = (T)value;
            }
        }
        /// <summary>
        /// Gets or sets the total number of elements the internal data structure can hold without resizing.
        /// </summary>
        public int Capacity
        {
            get
            {
                return _SourceList.Capacity;
            }
            set
            {
                // We cannot let them shrink capacity because this class is a wrapper for the List<T> in the _SourceList property.
                //  They don't get to see all the entries in that list because it is filtered.  Therefore it is not safe for them to shrink capacity.
                // We check if they are shrinking the capacity.
                if (value >= _SourceList.Capacity)
                {
                    _SourceList.Capacity = value;
                }
            }
        }
        /// <summary>
        /// Gets the number of elements contained in the <see cref="FilteredList{T}"/>.
        /// </summary>
        public int Count
        {
            get
            {
                List<T> Selected = _SourceList.Where(_Filter).ToList();
                return Selected.Count();
            }
        }
        /// <summary>
        /// Gets a value indicating whether the <see cref="FilteredList{T}"/> has a fixed size.
        /// </summary>
        public bool IsFixedSize
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets a value indicating whether the <see cref="FilteredList{T}"/> is read-only.
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets a value indicating whether access to the <see cref="FilteredList{T}"/> is synchronized (thread safe).
        /// </summary>
        public bool IsSynchronized
        {
            get
            {
                return false;
            }
        }
        /// <summary>
        /// Gets an object that can be used to synchronize access to the <see cref="FilteredList{T}"/>.
        /// </summary>
        public object SyncRoot
        {
            get
            {
                return _SourceList;
            }
        }
        #endregion
        #endregion
    }
}
