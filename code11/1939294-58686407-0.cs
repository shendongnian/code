    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<Record> records = new List<Record>() {
                    new Record() {
                        Count = 10,
                        Results = new List<Result>() {
                            new Result() { ResultType = ResultType.One, Value1 = "value1", Value2 = "value2"},
                            new Result() {ResultType = ResultType.One, Value1 = "other1", Value2 = "other2"},
                            new Result() {ResultType = ResultType.Zero, Value1 = "a", Value2 = "b"}
                        }
                    },
                    new Record() {
                        Count = 10,
                        Results = new List<Result>() {
                           new Result() {ResultType = ResultType.One, Value1 = "value1", Value2 = "value2"},
                           new Result() {ResultType = ResultType.One, Value1 = "other1", Value2 = "other2"},
                           new Result() {ResultType = ResultType.Zero, Value1 = "a", Value2 = "b"}
                        }
                    },
                    new Record() {
                        Count = 50,
                        Results = new List<Result>() {
                           new Result() {ResultType = ResultType.One, Value1 = "value1", Value2 = "value2"},
                           new Result() {ResultType = ResultType.Zero, Value1 = "a", Value2 = "b"}
                        }
                    }
                };
                var temp = records.Select(x => new { 
                    count = x.Count, 
                    CombinedResultType0 = x.Results.Where(y => y.ResultType == ResultType.Zero).Select(z => z.Value1 + "#" + z.Value2).FirstOrDefault(),
                    CombinedResultType1 = string.Join(",",x.Results.Where(y => y.ResultType == ResultType.One).Select(z => z.Value1 + "|" + z.Value2))
                }).ToList();
                var results = temp.GroupBy(x => new { zero = x.CombinedResultType0, one = x.CombinedResultType1 })
                    .Select(x => new { count = x.Sum(y => y.count), CombinedResultType0 = x.Key.zero, CombinedResultType1 = x.Key.one })
                    .ToList();
            }
        }
        public class Record 
        {
            public int Count { get; set; }
            public virtual List<Result> Results { get; set; }
        }
        public class Result
        {
            public int RecordId { get; set; }
            public Record Record { get; set; }
            public ResultType ResultType { get; set; }
            public string Value1 { get; set; }
            public string Value2 { get; set; }
        }
        public enum ResultType
        {
            Zero,
            One
        }
    }
