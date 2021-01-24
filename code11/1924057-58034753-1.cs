    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    
    namespace MyApp.ParallelStuff
    {
        public class ParallelExampleOne
        {
    
            public void ExampleOne()
            {
    
                ICollection<string> inputValues = new List<string>();
    
                for (int i = 1; i < 10000; i++)
                {
                    inputValues.Add("MyValue" + Convert.ToString(i));
                }
    
                CancellationTokenSource ct = new CancellationTokenSource();
    
                BlockingCollection<ResultObject> finalItems = new BlockingCollection<ResultObject>();
    
                Parallel.ForEach(inputValues, (currentInputItem) =>
                {
                    ResultObject ro = new ResultObject(currentInputItem.Length, currentInputItem);
    
                    if (ro.StringLength % 2 == 0)
                    {
                        finalItems.Add(ro);
                    }
    
                });
    
                Console.WriteLine("ExampleOne.finalItems.Count={0}", finalItems.Count);
                string temp = string.Empty;
            }
    
            public void ExampleTwo()
            {
    
                ICollection<string> inputValues = new List<string>();
                for (int i = 1; i < 10000; i++)
                {
                    inputValues.Add("MyValue" + Convert.ToString(i));
                }
    
                CancellationTokenSource ct = new CancellationTokenSource();
    
                BlockingCollection<ResultObject> finalItems = new BlockingCollection<ResultObject>();
    
                ParallelOptions options = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount, CancellationToken = ct.Token };
    
                ParallelLoopResult results = Parallel.ForEach(inputValues, options, currentInputValue =>
                {
                    ResultObject ro = new ResultObject(currentInputValue.Length, currentInputValue);
    
                    if (ro.StringLength % 2 == 0)
                    {
                        finalItems.Add(ro);
                    }
    
                });
    
                Console.WriteLine("ExampleTwo.finalItems.Count={0}", finalItems.Count);
    
                string temp = string.Empty;
            }
    
    
    
        internal class ResultObject
        {
            internal int StringLength { get; private set; }
            internal string OutputValue { get; private set; }
    
            public ResultObject(int stringLength, string inputValue)
            {
                this.StringLength = stringLength;
                this.OutputValue = inputValue + "MyOutputSuffix";
            }
        }
    
    }
