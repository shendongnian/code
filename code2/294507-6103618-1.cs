        public static IEnumerable<TResult> MergeJoin_OneToOne<TLeft, TRight, TResult>(
            IEnumerable<TLeft> leftCollection,
            IEnumerable<TRight> rightCollection,
            Func<TLeft, TRight, int> comparison,
            Func<TLeft, TResult> onlyLeftSelector,
            Func<TRight, TResult> onlyRightSelector,
            Func<TLeft, TRight, TResult> bothSelector)
        {
            return MergeJoin_OneToOne_Impl(leftCollection, rightCollection, comparison, onlyLeftSelector, onlyRightSelector, bothSelector);
        }
        static IEnumerable<TResult> MergeJoin_OneToOne_Impl<TLeft, TRight, TResult>(
            IEnumerable<TLeft> leftCollection,
            IEnumerable<TRight> rightCollection,
            Func<TLeft, TRight, int> comparison,
            Func<TLeft, TResult> onlyLeftSelector,
            Func<TRight, TResult> onlyRightSelector,
            Func<TLeft, TRight, TResult> bothSelector)
        {
            if (leftCollection == null) throw new ArgumentNullException("leftCollection");
            if (rightCollection == null) throw new ArgumentNullException("rightCollection");
            if (comparison == null) throw new ArgumentNullException("comparison");
            if (onlyLeftSelector == null) throw new ArgumentNullException("onlyLeftSelector");
            if (onlyRightSelector == null) throw new ArgumentNullException("onlyRightSelector");
            if (bothSelector == null) throw new ArgumentNullException("bothSelector");
            using (var leftEnum = leftCollection.GetEnumerator())
            using (var rightEnum = rightCollection.GetEnumerator())
            {
                if (!leftEnum.MoveNext())
                {
                    while (rightEnum.MoveNext()) yield return onlyRightSelector(rightEnum.Current);
                    yield break;
                }
                if (!rightEnum.MoveNext())
                {
                    do
                    {
                        yield return onlyLeftSelector(leftEnum.Current);
                    } while (leftEnum.MoveNext());
                    yield break;
                }
                while (true)
                {
                    int cmp = comparison(leftEnum.Current, rightEnum.Current);
                    if (cmp == 0)
                    {
                        yield return bothSelector(leftEnum.Current, rightEnum.Current);
                        if (!leftEnum.MoveNext())
                        {
                            while (rightEnum.MoveNext())
                            {
                                yield return onlyRightSelector(rightEnum.Current);
                            }
                            yield break;
                        }
                        if (!rightEnum.MoveNext())
                        {
                            do
                            {
                                yield return onlyLeftSelector(leftEnum.Current);
                            } while (leftEnum.MoveNext());
                            yield break;
                        }
                    }
                    else if (cmp < 0)
                    {
                        yield return onlyLeftSelector(leftEnum.Current);
                        if (!leftEnum.MoveNext())
                        {
                            do
                            {
                                yield return onlyRightSelector(rightEnum.Current);
                            } while (rightEnum.MoveNext());
                            yield break;
                        }
                    }
                    else
                    {
                        yield return onlyRightSelector(rightEnum.Current);
                        if (!rightEnum.MoveNext())
                        {
                            do
                            {
                                yield return onlyLeftSelector(leftEnum.Current);
                            } while (leftEnum.MoveNext());
                            yield break;
                        }
                    }
                }
            }
        }
