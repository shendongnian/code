    namespace CodeContractsSamples
    {
        public class MovieRepo
        {
            [Pure]
            public string GetMovieInfo(Movie movie)
            {
                Contract.Requires(movie != null && 
                                  !(string.IsNullOrEmpty(movie.Title) || 
                                    string.IsNullOrEmpty(movie.Description)));
                // This ensures was always invalid. Due to your format
                // string, this string was guaranteed to never be empty--
                // it would always contain at least ", ".
                //Contract.Ensures(Contract.Result<string>() != string.Empty);
                Contract.Ensures(!string.IsNullOrEmpty(Contract.Result<string>()));
                // Changed this line to use C# 6 -- see the below
                //return string.Format("{0}, {1}", movie.Title, movie.Description);
                // Help out the static analyzer--and yourself! First, we prove that
                // Title and Description are greater than 0.
                // These asserts aren't strictly needed, as this should
                // follow from the pre-conditions above. But, I put this
                // here just so you could follow the inference chain.
                Contract.Assert(movie.Title.Length > 0);
                Contract.Assert(movie.Description.Length > 0);
                // Introduce an intermediate variable to help the static analyzer
                var movieInfo = $"{movie.Title}, {movie.Description}";
                // The static analyzer doesn't understand String.Format(...) 
                // (or string interpolation). However, above, we asserted that the movie 
                // Title's and Description's length are both greater than zero. Since we
                // have proved that, then we can also prove that movieInfo's length is
                // at least Title.Length + Description.Length + 2 (for the ", ");
                // therefore, we know it's not null or empty.
                // Again, the static analyzer will never be able to figure this out on
                // it's own, so we tell it to assume that that's true. But, again, you
                // have proven to yourself that this is indeed true; so we can safely tell
                // the analyzer to assume this.
                // If this seems like a lot of bloat--this is the cost of provable
                // code--but you can rest assured that this method will always work the
                // way you intended if the stated pre-conditions hold true upon method
                // entry.
                Contract.Assume(!string.IsNullOrEmpty(movieInfo));
                return movieInfo;
            }
        }
        // Since this class contained only data, and no behavior,
        // I've changed this class to be an immutable value object.
        // Also, since the class is immutable, it's also pure (i.e.
        // no side-effects, so I've marked it as [Pure].
        [Pure]
        public class Movie : IEquatable<Movie>
        {
            private readonly string _title;
            private readonly string _description;
            [ContractInvariantMethod]
            [System.Diagnostics.CodeAnalysis.SuppressMessage(
                "Microsoft.Performance", 
                "CA1822:MarkMembersAsStatic", 
                Justification = "Required for code contracts.")]
            private void ObjectInvariant()
            {
                Contract.Invariant(!(string.IsNullOrWhiteSpace(_title) 
                    && string.IsNullOrWhiteSpace(_description)));
            }
            public Movie(string title, string description)
            {
                // NOTE: For Code Contracts 1.9.10714.2, you will need to
                //       modify the Microsoft.CodeContract.targets file located
                //       at C:\Program Files (x86)\Microsoft\Contracts\MSBuild\v14.0
                //       (for VS 2015) in order for Code Contracts to be happy
                //       with the call to System.String.IsNullOrWhiteSpace(string)
                //       See this GitHub issue: 
                //           https://github.com/Microsoft/CodeContracts/pull/359/files
                Contract.Requires(!(string.IsNullOrWhiteSpace(title) &&
                                    string.IsNullOrWhiteSpace(description)));
                Contract.Ensures(_title == title && 
                                 _description == description);
                _title = title;
                _description = description;
            }
            public string Title => _title;
            public string Description => _description;
            // Since this class is now an immutable value object, it's not
            // a bad idea to override Equals and GetHashCode() and implement
            // IEquatable<T>
            public override bool Equals(object obj)
            {
                if (obj == null || !this.GetType().Equals(obj.GetType()))
                {
                    return false;
                }
                Movie that = obj as Movie;
                return this.Equals(that);
            }
            public override int GetHashCode()
            {
                // Because we know _title and _description will
                // never be null due to class invariants, tell
                // Code Contracts to assume this fact.
                Contract.Assume(_title != null && _description != null);
                return _title.GetHashCode() ^ _description.GetHashCode();
            }
            public bool Equals(Movie other)
            {
                if (other == null)
                {
                    return false;
                }
                return this._title == other._title &&
                       this._description == other._description;
            }
            public static bool operator == (Movie movie1, Movie movie2)
            {
                if (((object)movie1) == null || ((object)movie2) == null)
                {
                    return object.Equals(movie1, movie2);
                }
                return movie1.Equals(movie2);
            }
            public static bool operator != (Movie movie1, Movie movie2)
            {
                if (((object)movie1) == null || ((object)movie2) == null)
                {
                    return !object.Equals(movie1, movie2);
                }
                return !movie1.Equals(movie2);
            }
        }
    }
