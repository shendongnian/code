    namespace AI.Collections {
        using System;
        using System.Collections;
        using System.Collections.Generic;
        using System.Linq;
        using System.Runtime.Serialization;
        using System.Threading.Tasks;
        using System.Threading.Tasks.Dataflow;
    
        /// <summary>
        ///     Just a simple thread safe collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <value>Version 1.5</value>
        /// <remarks>TODO replace locks with AsyncLocks</remarks>
        [DataContract( IsReference = true )]
        public class ThreadSafeList<T> : IList<T> {
            /// <summary>
            ///     TODO replace the locks with a ReaderWriterLockSlim
            /// </summary>
            [DataMember]
            private readonly List<T> _items = new List<T>();
    
            public ThreadSafeList( IEnumerable<T> items = null ) { this.Add( items ); }
    
            public long LongCount {
                get {
                    lock ( this._items ) {
                        return this._items.LongCount();
                    }
                }
            }
    
            public IEnumerator<T> GetEnumerator() { return this.Clone().GetEnumerator(); }
    
            IEnumerator IEnumerable.GetEnumerator() { return this.GetEnumerator(); }
    
            public void Add( T item ) {
                if ( Equals( default( T ), item ) ) {
                    return;
                }
                lock ( this._items ) {
                    this._items.Add( item );
                }
            }
    
            public Boolean TryAdd( T item ) {
                try {
                    if ( Equals( default( T ), item ) ) {
                        return false;
                    }
                    lock ( this._items ) {
                        this._items.Add( item );
                        return true;
                    }
                }
                catch ( NullReferenceException ) { }
                catch ( ObjectDisposedException ) { }
                catch ( ArgumentNullException ) { }
                catch ( ArgumentOutOfRangeException ) { }
                catch ( ArgumentException ) { }
                return false;
            }
    
            public void Clear() {
                lock ( this._items ) {
                    this._items.Clear();
                }
            }
    
            public bool Contains( T item ) {
                lock ( this._items ) {
                    return this._items.Contains( item );
                }
            }
    
            public void CopyTo( T[] array, int arrayIndex ) {
                lock ( this._items ) {
                    this._items.CopyTo( array, arrayIndex );
                }
            }
    
            public bool Remove( T item ) {
                lock ( this._items ) {
                    return this._items.Remove( item );
                }
            }
    
            public int Count {
                get {
                    lock ( this._items ) {
                        return this._items.Count;
                    }
                }
            }
    
            public bool IsReadOnly { get { return false; } }
    
            public int IndexOf( T item ) {
                lock ( this._items ) {
                    return this._items.IndexOf( item );
                }
            }
    
            public void Insert( int index, T item ) {
                lock ( this._items ) {
                    this._items.Insert( index, item );
                }
            }
    
            public void RemoveAt( int index ) {
                lock ( this._items ) {
                    this._items.RemoveAt( index );
                }
            }
    
            public T this[ int index ] {
                get {
                    lock ( this._items ) {
                        return this._items[ index ];
                    }
                }
                set {
                    lock ( this._items ) {
                        this._items[ index ] = value;
                    }
                }
            }
    
            /// <summary>
            ///     Add in an enumerable of items.
            /// </summary>
            /// <param name="collection"></param>
            /// <param name="asParallel"></param>
            public void Add( IEnumerable<T> collection, Boolean asParallel = true ) {
                if ( collection == null ) {
                    return;
                }
                lock ( this._items ) {
                    this._items.AddRange( asParallel
                                                  ? collection.AsParallel().Where( arg => !Equals( default( T ), arg ) )
                                                  : collection.Where( arg => !Equals( default( T ), arg ) ) );
                }
            }
    
            public Task AddAsync( T item ) {
                return Task.Factory.StartNew( () => { this.TryAdd( item ); } );
            }
    
            /// <summary>
            ///     Add in an enumerable of items.
            /// </summary>
            /// <param name="collection"></param>
            public Task AddAsync( IEnumerable<T> collection ) {
                if ( collection == null ) {
                    throw new ArgumentNullException( "collection" );
                }
    
                var produce = new TransformBlock<T, T>( item => item, new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = Environment.ProcessorCount } );
    
                var consume = new ActionBlock<T>( action: async obj => await this.AddAsync( obj ), dataflowBlockOptions: new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = Environment.ProcessorCount } );
                produce.LinkTo( consume );
    
                return Task.Factory.StartNew( async () => {
                    collection.AsParallel().ForAll( item => produce.SendAsync( item ) );
                    produce.Complete();
                    await consume.Completion;
                } );
            }
    
            /// <summary>
            ///     Returns a new copy of all items in the <see cref="List{T}" />.
            /// </summary>
            /// <returns></returns>
            public List<T> Clone( Boolean asParallel = true ) {
                lock ( this._items ) {
                    return asParallel
                                   ? new List<T>( this._items.AsParallel() )
                                   : new List<T>( this._items );
                }
            }
    
            /// <summary>
            ///     Perform the <paramref name="action" /> on each item in the list.
            /// </summary>
            /// <param name="action">
            ///     <paramref name="action" /> to perform on each item.
            /// </param>
            /// <param name="performActionOnClones">
            ///     If true, the <paramref name="action" /> will be performed on a <see cref="Clone" /> of the items.
            /// </param>
            /// <param name="asParallel">
            ///     Use the <see cref="ParallelQuery{TSource}" /> method.
            /// </param>
            /// <param name="inParallel">
            ///     Use the
            ///     <see
            ///         cref="Parallel.ForEach{TSource}(System.Collections.Generic.IEnumerable{TSource},System.Action{TSource})" />
            ///     method.
            /// </param>
            public void ForEach( Action<T> action, Boolean performActionOnClones = true, Boolean asParallel = true, Boolean inParallel = false ) {
                if ( action == null ) {
                    throw new ArgumentNullException( "action" );
                }
                var wrapper = new Action<T>( obj => {
                    try {
                        action( obj );
                    }
                    catch ( ArgumentNullException ) {
                        //if a null gets into the list then swallow an ArgumentNullException so we can continue adding
                    }
                } );
                if ( performActionOnClones ) {
                    var clones = this.Clone( asParallel: asParallel );
                    if ( asParallel ) {
                        clones.AsParallel().ForAll( wrapper );
                    }
                    else if ( inParallel ) {
                        Parallel.ForEach( clones, wrapper );
                    }
                    else {
                        clones.ForEach( wrapper );
                    }
                }
                else {
                    lock ( this._items ) {
                        if ( asParallel ) {
                            this._items.AsParallel().ForAll( wrapper );
                        }
                        else if ( inParallel ) {
                            Parallel.ForEach( this._items, wrapper );
                        }
                        else {
                            this._items.ForEach( wrapper );
                        }
                    }
                }
            }
    
            /// <summary>
            ///     Perform the <paramref name="action" /> on each item in the list.
            /// </summary>
            /// <param name="action">
            ///     <paramref name="action" /> to perform on each item.
            /// </param>
            /// <param name="performActionOnClones">
            ///     If true, the <paramref name="action" /> will be performed on a <see cref="Clone" /> of the items.
            /// </param>
            /// <param name="asParallel">
            ///     Use the <see cref="ParallelQuery{TSource}" /> method.
            /// </param>
            /// <param name="inParallel">
            ///     Use the
            ///     <see
            ///         cref="Parallel.ForEach{TSource}(System.Collections.Generic.IEnumerable{TSource},System.Action{TSource})" />
            ///     method.
            /// </param>
            public void ForAll( Action<T> action, Boolean performActionOnClones = true, Boolean asParallel = true, Boolean inParallel = false ) {
                if ( action == null ) {
                    throw new ArgumentNullException( "action" );
                }
                var wrapper = new Action<T>( obj => {
                    try {
                        action( obj );
                    }
                    catch ( ArgumentNullException ) {
                        //if a null gets into the list then swallow an ArgumentNullException so we can continue adding
                    }
                } );
                if ( performActionOnClones ) {
                    var clones = this.Clone( asParallel: asParallel );
                    if ( asParallel ) {
                        clones.AsParallel().ForAll( wrapper );
                    }
                    else if ( inParallel ) {
                        Parallel.ForEach( clones, wrapper );
                    }
                    else {
                        clones.ForEach( wrapper );
                    }
                }
                else {
                    lock ( this._items ) {
                        if ( asParallel ) {
                            this._items.AsParallel().ForAll( wrapper );
                        }
                        else if ( inParallel ) {
                            Parallel.ForEach( this._items, wrapper );
                        }
                        else {
                            this._items.ForEach( wrapper );
                        }
                    }
                }
            }
        }
    }
