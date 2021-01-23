    public class RandomScoreQuery : Lucene.Net.Search.Function.CustomScoreQuery
	{
	   Random r = new Random((int)(DateTime.Now.Ticks & 0x7fffffff));
	   public RandomScoreQuery(Query q): base(q)
	   {
	   }
	   public override float CustomScore(int doc, float subQueryScore, float valSrcScore)
	   {
		   return r.Next(10000) / 1000.0f; //rand scores between 0-10
	   }
    } 
    Query q1 =  new TermQuery(new Term("content", "test"));
    Query q2 = new RandomScoreQuery(q1);
    TopDocs td = src.Search(q2, 100);
