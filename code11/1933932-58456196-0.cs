    public static class FrameMutator
    {
        /// <summary>
        /// For a frame of type Frame<TRow,TCol> mutate its rows of type TVal and create a new column with the results
        /// </summary>
        /// <typeparam name="TRow">Row Type</typeparam>
        /// <typeparam name="TVal">Value Type</typeparam>
        /// <typeparam name="TCol">Column Type</typeparam>
        /// <param name="myFrame"></param>
        /// <param name="mutatorMethod">delegate for transformation</param>
        /// <returns>Series<K, V></returns>
        public static Series<TRow, TVal> Mutate<TRow,TVal,TCol>(this Frame<TRow, TCol> myFrame, Func<TVal[], TVal> mutatorMethod)
        {
            SeriesBuilder<TRow, TVal> result = new SeriesBuilder<TRow, TVal>();
            foreach (TRow key in myFrame.Rows.Keys)
            {
                TVal colResult = mutatorMethod(myFrame.Rows[key].GetValues<TVal>().ToArray());
                result.Add(key, colResult);
            }
            return result.ToSeries();
        }
    }
