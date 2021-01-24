var batchPrediction = _predEngine;
Console.WriteLine($"Prediction: {batchPrediction.Predict(prediction)}"); 
In addition, I removed the following line:
IDataView predictions = loadedModel.Transform(batchIssues);
The removal of this function made no difference to the outcome of prediction.
The full code that seemed to have worked is as follows:
IEnumerable<GitHubIssue> issues = new[]
{
    new GitHubIssue
    {
         Title = "Entity Framework crashes",
         Description = "When connecting to the database, EF is crashing"
    },
    new GitHubIssue
    {
         Title = "Github Down",
         Description = "When going to the website, github says it is down"
    }
};
var batchPrediction = _predEngine;
// Batch Predictions from Enumerable
IDataView batchIssues = _mlContext.Data.LoadFromEnumerable(issues);
            
IEnumerable<GitHubIssue> predictedResults = _mlContext.Data.CreateEnumerable<GitHubIssue>(batchIssues, reuseRowObject: false);
foreach (GitHubIssue prediction in predictedResults)
{
        Console.WriteLine($"Title: {prediction.Title} | Prediction: {batchPrediction.Predict(prediction)}");
}
**Answer to Problem 2**
I created a new file with the ID, Area (this is left blank), Title and Description and mirrors the test and training data files.
I added two variables to the global scope (just below the namespace) as follows:
private static string _myTestDataPath => Path.Combine(_appPath, "..", "..", "..", "Data", "myTestData.tsv");
private static IDataView _myTestDataView;
Instead of creating a IEnumerable, I passed the file in directly, as follows:
_myTestDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_myTestDataPath, hasHeader: true);
The following is a full example of the method:
ITransformer loadedModel = _mlContext.Model.Load(_modelPath, out var modelInputSchema);
_predEngine = _mlContext.Model.CreatePredictionEngine<GitHubIssue, IssuePrediction>(loadedModel);
_myTestDataView = _mlContext.Data.LoadFromTextFile<GitHubIssue>(_myTestDataPath, hasHeader: true);
IDataView predictions = loadedModel.Transform(_myTestDataView);
var batchPrediction = _predEngine;
IEnumerable<GitHubIssue> predictedResults =
    _mlContext.Data.CreateEnumerable<GitHubIssue>(predictions, reuseRowObject: false);
foreach (GitHubIssue prediction in predictedResults)
{
    Console.WriteLine($"Title: {prediction.Title} | Prediction: {batchPrediction.Predict(prediction).Area}");
}
*As a side note, comparing the batchPredictions of the manually generated issues, to the file based issues. You must include the .Area to the end of the output as shown on the last line*
// Manual Batch Predictions
Console.WriteLine($"Title: {prediction.Title} | Prediction: {batchPrediction.Predict(prediction)}");
// File-based Batch Predictions
Console.WriteLine($"Title: {prediction.Title} | Prediction: {batchPrediction.Predict(prediction).Area}");
