public static void ChangeWordsToLinks()
{
  Dictionary<string, string> _wordLinkCollection = new Dicationary<string, string>();
  // fill the collection which will replace words by links here
  // Additionally you can fetch this from a database and loop 
  // through a DataTable to fill this collection
  _wordLinkCollection.add("foo", "http://www.foobar.com");
  _wordLinkCollection.add("bar", "http://www.barfoo.com");
  // this is lazy code and SHOULD be optimized to a single RegExp string.
  foreach(KayValuePair&lt;string, string&gt; pair in _wordLinkCollection)
  {
    _pageContent.Replace(String.Format(" {0} ", pair.Key), 
        String.Format("&lt;a href='{0}'&gt;{1}&lt;/a&gt;", pair.Value, pair.Key));
  }
}
