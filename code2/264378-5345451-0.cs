     public class WSClient {
          public int GetPower (int var) { return var * var; }
          public int[] GetDuplicatePowers (int var) {
                  return new[] { GetPower(var), GetPower (var) };
          }
     }
     public class Multiplexer<T> {
          IList<T> _sources;
          public Multiplexer (IEnumerable<T> sources) {
                 _sources = new List<T> (sources);
          }
          public IEnumerable<TResult> Call<TResult> (Func<T, TResult> func) {
              return _sources.Select (s => func(s));
          }
          public IEnumerable<TResult> AggregateCall<TResult> (Func<T, IEnumerable<TResult>> func) {
              return _sources.SelectMany (s => func(s));
          }
     }
     public class Test {
         public static void Main (string[] args) {
               var m = new Multiplexer<WSClient> (new[] { new WSClient (), new WSClient () });
               var powers = m.Call (c => c.GetPower (2));
               var agg_powers = m.AggregateCall (c => c.GetDuplicatePowers (2));
         }
     }
