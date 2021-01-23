    /// <summary>
    /// Projects a window of source elements in a source sequence into target sequence.
    /// Thus
    ///   target[i] = 
    ///     selector(source[i], source[i - 1], ... source[i - window + 1])
    /// </summary>
    /// <typeparam name="T">A type of elements of source sequence.</typeparam>
    /// <typeparam name="R">A type of elements of target sequence.</typeparam>
    /// <param name="source">A source sequence.</param>
    /// <param name="window">A size of window.</param>
    /// <param name="lookbehind">
    /// Indicate whether to produce target if the number of source elements 
    /// preceeding the current is less than the window size.
    /// </param>
    /// <param name="lookahead">
    /// Indicate whether to produce target if the number of source elements 
    /// following current is less than the window size.
    /// </param>
    /// <param name="selector">
    /// A selector that derives target element.
    /// On input it receives:
    ///   an array of source elements stored in round-robing fashon;
    ///   an index of the first element;
    ///   a number of elements in the array to count.
    /// </param>
    /// <returns>Returns a sequence of target elements.</returns>
    public static IEnumerable<R> Window<T, R>(
      this IEnumerable<T> source,
      int window,
      bool lookbehind,
      bool lookahead,
      Func<T[], int, int, R> selector)
    {
      var buffer = new T[window];
      var index = 0;
      var count = 0;
      foreach(var value in source)
      {
        if (count < window)
        {
          buffer[count++] = value;
          if (lookbehind || (count == window))
          {
            yield return selector(buffer, 0, count);
          }
        }
        else
        {
          buffer[index] = value;
          index = index + 1 == window ? 0 : index + 1;
          yield return selector(buffer, index, count);
        }
      }
      if (lookahead)
      {
        while(--count > 0)
        {
          index = index + 1 == window ? 0 : index + 1;
          yield return selector(buffer, index, count);
        }
      }
    }
    /// <summary>
    /// Projects a window of source elements in a source sequence into a 
    /// sequence of window arrays.
    /// </summary>
    /// <typeparam name="T">A type of elements of source sequence.</typeparam>
    /// <typeparam name="R">A type of elements of target sequence.</typeparam>
    /// <param name="source">A source sequence.</param>
    /// <param name="window">A size of window.</param>
    /// <param name="lookbehind">
    /// Indicate whether to produce target if the number of source elements 
    /// preceeding the current is less than the window size.
    /// </param>
    /// <param name="lookahead">
    /// Indicate whether to produce target if the number of source elements 
    /// following current is less than the window size.
    /// </param>
    /// <returns>Returns a sequence of windows.</returns>
    public static IEnumerable<T[]> Window<T>(
      this IEnumerable<T> source,
      int window,
      bool lookbehind,
      bool lookahead)
    {
      return source.Window(
        window,
        lookahead,
        lookahead,
        (buffer, index, count) =>
        {
          var result = new T[count];
          for(var i = 0; i < count; ++i)
          {
            result[i] = buffer[index];
            index = index + 1 == buffer.Length ? 0 : index + 1;
          }
          return result;
        });
    }
