    internal class ListLambdaLINQSample
    {
        List<KeyValuePair<Colors, int>> listSource;
        List<KeyValuePair<Colors, int>> listCriteria;
        List<KeyValuePair<Colors, int>> listMatches;
        private const int COLORCODE1 = 1;
        private const int COLORCODE2 = 2;
        private const int COLORCODE3 = 3;
        private const int COLORCODE4 = 4;
        private const int COLORCODE5 = 5;
        internal enum Colors
        {
            Red, Blue, Green, Yellow
        }
        public ListLambdaLINQSample()
        {   // populate the list
            listSource = new List<KeyValuePair<Colors, int>>();
            listCriteria = new List<KeyValuePair<Colors, int>>();
            _populateListCriteria();
            _populateListSource();
            
            ...
        }
        private void _getMatchesWithLINQ()
        {
            listMatches =
                            (from kvpInList
                                 in listSource
                             where !listCriteria.Contains(kvpInList)
                             select kvpInList).ToList();
        }
        private void _getMatchesWithLambda()
        {
            listMatches =
                listSource.Where(kvpInList => !listCriteria.Contains(kvpInList)).ToList();
        }
        private void _populateListSource()
        {
            listSource.Add(new KeyValuePair<Colors, int>(Colors.Blue, COLORCODE1));
            listSource.Add(new KeyValuePair<Colors, int>(Colors.Green, COLORCODE2));
            listSource.Add(new KeyValuePair<Colors, int>(Colors.Red, COLORCODE3));
            listSource.Add(new KeyValuePair<Colors, int>(Colors.Yellow, COLORCODE4));
        }
        private void _populateListCriteria()
        {
            listCriteria.Add(new KeyValuePair<Colors, int>(Colors.Blue, COLORCODE1));
            listCriteria.Add(new KeyValuePair<Colors, int>(Colors.Green, COLORCODE2));
        }
    }
