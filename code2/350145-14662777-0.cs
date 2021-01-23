    var moreLikeThis = new Lucene.Net.Search.Similar.MoreLikeThis(indexReader);
    moreLikeThis.SetAnalyzer(analyzer);
    moreLikeThis.SetFieldNames(fieldNames);
    moreLikeThis.SetStopWords(stopWords);
    moreLikeThis.SetMinWordLen(2);
    var query = moreLikeThis.Like(new System.IO.StringReader(similarity));
