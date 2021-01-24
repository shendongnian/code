    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks.Dataflow;
    
    namespace ParallelDataFlow
    {
        class Program
        {
            static void Main(string[] args)
            {
                new Program().Run();
                Console.ReadLine();
            }
    
            private void Run()
            {
                Stopwatch s = new Stopwatch();
                s.Start();
    
                // Can  experiment with parallelization of blocks by changing MaxDegreeOfParallelism
                var options = new ExecutionDataflowBlockOptions { MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded };
                var getInputPathsBlock = new TransformManyBlock<(int, int), WorkItem>(date => GetWorkItemWithInputPath(date), options);
                var loadDataBlock = new TransformBlock<WorkItem, WorkItem>(workItem => LoadDataIntoWorkItem(workItem), options);
                var processDataBlock = new TransformBlock<WorkItem, WorkItem>(workItem => ProcessDataForWorkItem(workItem), options);
                var waitForProcessedDataBlock = new TransformManyBlock<WorkItem, List<WorkItem>>(workItem => WaitForWorkItems(workItem));  // Can't parallelize this block
                var mergeDataBlock = new TransformBlock<List<WorkItem>, List<WorkItem>>(list => MergeWorkItemData(list), options);
                var saveDataBlock = new ActionBlock<List<WorkItem>>(list => SaveWorkItemData(list), options);
    
                var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };
                getInputPathsBlock.LinkTo(loadDataBlock, linkOptions);
                loadDataBlock.LinkTo(processDataBlock, linkOptions);
                processDataBlock.LinkTo(waitForProcessedDataBlock, linkOptions);
                waitForProcessedDataBlock.LinkTo(mergeDataBlock, linkOptions);
                mergeDataBlock.LinkTo(saveDataBlock, linkOptions);
                           
                // We post individual tuples of (year, month) to our pipeline, as many as we want
                getInputPathsBlock.Post((1903, 2));  // Post one month and date
                var dates = from y in Enumerable.Range(2015, 5) from m in Enumerable.Range(1, 12) select (y, m);
                foreach (var date in dates) getInputPathsBlock.Post(date);  // Post a big sequence         
    
                getInputPathsBlock.Complete();
                saveDataBlock.Completion.Wait();
                s.Stop();
                Console.WriteLine($"Completed in {s.ElapsedMilliseconds}ms on {ThreadAndTime()}");
            }
    
            private IEnumerable<WorkItem> GetWorkItemWithInputPath((int year, int month) date)
            {
                List<WorkItem> processedWorkItems = new List<WorkItem>();  // Will store merged results
                return GetInputPaths(date.year, date.month).Select(
                    path => new WorkItem
                    {
                        Year = date.year,
                        Month = date.month,
                        FilePath = path,
                        ProcessedWorkItems = processedWorkItems
                    });
            }
    
            // Get filepaths of form e.g. Files/20191101.txt  These aren't real files, they just show how it could work.
            private IEnumerable<string> GetInputPaths(int year, int month) =>
                Enumerable.Range(0, GetNumberOfFiles(year, month)).Select(i => $@"Files/{year}{Pad(month)}{Pad(i + 1)}.txt");
    
            private int GetNumberOfFiles(int year, int month) => DateTime.DaysInMonth(year, month);
    
            private WorkItem LoadDataIntoWorkItem(WorkItem workItem) {
                workItem.RawData = LoadData(workItem.FilePath);
                return workItem;
            }
    
            // Simulate loading by just concatenating to path: in real code this could open a real file and return the contents
            private string LoadData(string path) => "This is content from file " + path;
    
            private WorkItem ProcessDataForWorkItem(WorkItem workItem)
            {
                workItem.ProcessedData = ProcessData(workItem.RawData);
                return workItem;
            }
    
            private string ProcessData(string contents)
            {
                Thread.SpinWait(11000000); // Use 11,000,000 for ~50ms on Windows .NET Framework.  1,100,000 on Windows .NET Core.
                return $"Results of processing file with contents '{contents}' on {ThreadAndTime()}";
            }
    
            // Adds a processed WorkItem to its ProcessedWorkItems list.  Then checks if the list has as many processed WorkItems as we 
            // expect to see overall.  If so the list is returned to the next block, if not we return an empty array, which passes nothing on.
            // This isn't threadsafe for the list, so has to be called with MaxDegreeOfParallelization = 1
            private IEnumerable<List<WorkItem>> WaitForWorkItems(WorkItem workItem)
            {
                List<WorkItem> itemList = workItem.ProcessedWorkItems;
                itemList.Add(workItem);
                return itemList.Count == GetNumberOfFiles(workItem.Year, workItem.Month) ? new[] { itemList } : new List<WorkItem>[0];
            }
    
            private List<WorkItem> MergeWorkItemData(List<WorkItem> processedWorkItems)
            {
                string finalContents = "";
                foreach (WorkItem workItem in processedWorkItems)
                {
                    finalContents = MergeData(finalContents, workItem.ProcessedData);
                }
                // Should really create a new data structure and return that, but let's cheat a bit
                processedWorkItems[0].MergedData = finalContents;
                return processedWorkItems;
            }
    
            // Just concatenate the output strings, separated by newlines, to merge our data
            private string MergeData(string output1, string output2) => output1 != "" ? output1 + "\n" + output2 : output2;
    
            private void SaveWorkItemData(List<WorkItem> workItems)
            {
                WorkItem result = workItems[0];
                SaveData(result.MergedData, result.Year, result.Month);
                // Code to show it's worked...
                Console.WriteLine($"Saved data block for {DateToString((result.Year, result.Month))} on {ThreadAndTime()}." +
                                  $"  File contents:\n{result.MergedData}\n");
            }
            private void SaveData(string finalContents, int year, int month)
            {
                // Actually save, although don't really need to in this test code
                new DirectoryInfo("Results").Create();
                File.WriteAllText(Path.Combine("Results", $"results{year}{Pad(month)}.txt"), finalContents);
            }
    
            // Helper methods
            private string DateToString((int year, int month) date) => date.year + Pad(date.month);
            private string Pad(int number) => number < 10 ? "0" + number : number.ToString();
            private string ThreadAndTime() => $"thread {Pad(Thread.CurrentThread.ManagedThreadId)} at {DateTime.Now.ToString("hh:mm:ss.fff")}";
        }
    
        public class WorkItem
        {
            public int Year { get; set; }
            public int Month { get; set; }
            public string FilePath { get; set; }
            public string RawData { get; set; }
            public string ProcessedData { get; set; }
            public List<WorkItem> ProcessedWorkItems { get; set; }
            public string MergedData { get; set; }
        }
    }
