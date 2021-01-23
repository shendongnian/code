    namespace Code
    {
        using System;
        using System.Collections.Generic;
        using System.Linq;
    
        /// <summary>
        /// A generic implementation of the Knuth-Morris-Pratt algorithm that searches,
        /// in a memory efficient way, over a given <see cref="IEnumerable{T}"/>.
        /// </summary>
        public static class KMP
        {
            /// <summary>
            /// Determines whether a sequence contains the search string.
            /// </summary>
            /// <typeparam name="T">
            /// The type of elements of <paramref name="source"/>
            /// </typeparam>
            /// <param name="source">
            /// A sequence of elements
            /// </param>
            /// <param name="pattern">The search string.</param>
            /// <param name="equalityComparer">
            /// Determines whether the sequence contains a specified element.
            /// If <c>null</c>
            /// <see cref="EqualityComparer{T}.Default"/> will be used.
            /// </param>
            /// <returns>
            /// <c>true</c> if the source contains the specified pattern;
            /// otherwise, <c>false</c>.
            /// </returns>
            /// <exception cref="ArgumentNullException">pattern</exception>
            public static bool Contains<T>(
                    this IEnumerable<T> source,
                    IEnumerable<T> pattern,
                    IEqualityComparer<T> equalityComparer = null)
            {
                if (pattern == null)
                {
                    throw new ArgumentNullException(nameof(pattern));
                }
    
                equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
    
                return SearchImplementation(source, pattern, equalityComparer).Any();
            }
    
            public static IEnumerable<long> IndicesOf<T>(
                    this IEnumerable<T> source,
                    IEnumerable<T> pattern,
                    IEqualityComparer<T> equalityComparer = null)
            {
                if (pattern == null)
                {
                    throw new ArgumentNullException(nameof(pattern));
                }
    
                equalityComparer = equalityComparer ?? EqualityComparer<T>.Default;
    
                return SearchImplementation(source, pattern, equalityComparer);
            }
    
            /// <summary>
            /// Identifies indices of a pattern string in a given sequence.
            /// </summary>
            /// <typeparam name="T">
            /// The type of elements of <paramref name="source"/>
            /// </typeparam>
            /// <param name="source">
            /// The sequence to search.
            /// </param>
            /// <param name="patternString">
            /// The string to find in the sequence.
            /// </param>
            /// <param name="equalityComparer">
            /// Determines whether the sequence contains a specified element.
            /// </param>
            /// <returns>
            /// A sequence of indices where the pattern can be found
            /// in the source.
            /// </returns>
            /// <exception cref="ArgumentOutOfRangeException">
            /// patternSequence - The pattern must contain 1 or more elements.
            /// </exception>
            private static IEnumerable<long> SearchImplementation<T>(
                IEnumerable<T> source,
                IEnumerable<T> patternString,
                IEqualityComparer<T> equalityComparer)
            {
                // Pre-process the pattern
                (var slide, var pattern) = GetSlide(patternString, equalityComparer);
                var patternLength = pattern.Count;
    
                if (patternLength == 0)
                {
                    throw new ArgumentOutOfRangeException(
                        nameof(patternString),
                        "The pattern must contain 1 or more elements.");
                }
    
                var buffer = new Dictionary<long, T>(patternLength);
                var more = true;
    
                long sourceIndex = 0; // index for source
                int patternIndex = 0; // index for pattern
    
                using(var sourceEnumerator = source.GetEnumerator())
                while (more)
                {
                    more = FillBuffer(
                            buffer,
                            sourceEnumerator,
                            sourceIndex,
                            patternLength,
                            out T t);
    
                    if (equalityComparer.Equals(pattern[patternIndex], t))
                    {
                        patternIndex++;
                        sourceIndex++;
    
                        more = FillBuffer(
                            buffer,
                            sourceEnumerator,
                            sourceIndex,
                            patternLength,
                            out t);
                    }
    
                    if (patternIndex == patternLength)
                    {
                        yield return sourceIndex - patternIndex;
                        patternIndex = slide[patternIndex - 1];
                    }
                    else if (more && !equalityComparer.Equals(pattern[patternIndex], t))
                    {
                        if (patternIndex != 0)
                        {
                            patternIndex = slide[patternIndex - 1];
                        }
                        else
                        {
                            sourceIndex = sourceIndex + 1;
                        }
                    }
                }
            }
    
            /// <summary>
            /// Services the buffer and retrieves the value.
            /// </summary>
            /// <remarks>
            /// The buffer is used so that it is not necessary to hold the
            /// entire source in memory.
            /// </remarks>
            /// <typeparam name="T">
            /// The type of elements of <paramref name="source"/>.
            /// </typeparam>
            /// <param name="buffer">The buffer.</param>
            /// <param name="source">The source enumerator.</param>
            /// <param name="sourceIndex">The element index to retrieve.</param>
            /// <param name="patternLength">Length of the search string.</param>
            /// <param name="value">The element value retrieved from the source.</param>
            /// <returns>
            /// <c>true</c> if there is potentially more data to process;
            /// otherwise <c>false</c>.
            /// </returns>
            private static bool FillBuffer<T>(
                IDictionary<long, T> buffer,
                IEnumerator<T> source,
                long sourceIndex,
                int patternLength,
                out T value)
            {
                bool more = true;
                if (!buffer.TryGetValue(sourceIndex, out value))
                {
                    more = source.MoveNext();
                    if (more)
                    {
                        value = source.Current;
                        buffer.Remove(sourceIndex - patternLength);
                        buffer.Add(sourceIndex, value);
                    }
                }
    
                return more;
            }
    
            /// <summary>
            /// Gets the offset array which acts as a slide rule for the KMP algorithm.
            /// </summary>
            /// <typeparam name="T">
            /// The type of elements of <paramref name="source"/>.
            /// </typeparam>
            /// <param name="pattern">The search string.</param>
            /// <param name="equalityComparer">
            /// Determines whether the sequence contains a specified element.
            /// If <c>null</c>
            /// <see cref="EqualityComparer{T}.Default"/> will be used.
            /// </param>
            /// <returns>A tuple of the offsets and the enumerated pattern.</returns>
            private static (IReadOnlyList<int> Slide, IReadOnlyList<T> Pattern) GetSlide<T>(
                    IEnumerable<T> pattern,
                    IEqualityComparer<T> equalityComparer)
            {
                var patternList = pattern.ToList();
                var slide = new int[patternList.Count];
    
                int length = 0;
                int patternIndex = 1;
    
                while (patternIndex < patternList.Count)
                {
                    if (equalityComparer.Equals(
                            patternList[patternIndex],
                            patternList[length]))
                    {
                        length++;
                        slide[patternIndex] = length;
                        patternIndex++;
                    }
                    else
                    {
                        if (length != 0)
                        {
                            length = slide[length - 1];
                        }
                        else
                        {
                            slide[patternIndex] = length;
                            patternIndex++;
                        }
                    }
                }
    
                return (slide, patternList);
            }
        }
    }
