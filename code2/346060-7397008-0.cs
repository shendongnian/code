    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        public class GameInfo
        {
            public int UserId { get; set; }
            public int MatchesWon { get; set; }
            public long BulletsFired { get; set; }
            public string LastLevelVisited { get; set; }
            // thousands more of these
        }
    
        public class MyResult
        {
            public int UserId { get; set; }  // user id from above object
            public string ResultValue { get; set; }  // one of the value fields from above with .ToString() executed on it
        }
    
        public enum DataType
        {
            MatchesWon = 1,
            BulletsFired = 2,
            // add more as needed
        }
    
        class Program
        {
    
            private static Dictionary<DataType, Func<GameInfo, object>> getDataFuncs
                = new Dictionary<DataType, Func<GameInfo, object>>
                {
                    { DataType.MatchesWon, info => info.MatchesWon },
                    { DataType.BulletsFired, info => info.BulletsFired },
                    // add more as needed
                };
    
            public static IEnumerable<MyResult> GetMyResult(GameInfo[] gameInfos, DataType input)
            {
                var getDataFunc = getDataFuncs[input];
    
                return gameInfos.Select(info => new MyResult()
                        {
                        UserId = info.UserId,
                        ResultValue = getDataFunc(info).ToString()
                        });
            }
    
            static void Main(string[] args)
            {
                var testData = new GameInfo[] {
                    new GameInfo { UserId="a", BulletsFired = 99, MatchesWon = 2 },
                    new GameInfo { UserId="b", BulletsFired = 0, MatchesWon = 0 },
                };
    
                // you can now easily select whatever data you need, in a type-safe manner
                var dataToGet = DataType.MatchesWon;
                var results = GetMyResult(testData, dataToGet);
            }
    
        }
    }
