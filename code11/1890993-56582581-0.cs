C#
TestResultsCommand = new DelegateCommand(async () => await OnTestResultExecuteAsync());
public async Task OnTestResultExecuteAsync()
{
  TokenSource = new CancellationTokenSource();
  CancellationToken = TokenSource.Token;
  await TestHistoricalResultsAsync();
}
[Fact]
public async Task OnTestResultExecuteAsync_ShouldCreateCancellationTokenSource_True()
{
  CancellationTokenSource tokenSource = new CancellationTokenSource();
  CancellationToken cancellationToken = tokenSource.Token;
  await _viewModel.OnTestResultExecuteAsync();
  Assert.Equal(cancellationToken.CanBeCanceled, _viewModel.CancellationToken.CanBeCanceled);
  Assert.Equal(cancellationToken.IsCancellationRequested, _viewModel.CancellationToken.IsCancellationRequested);
}
If you don't want to expose `async Task` methods just for the sake of unit testing, then you can use an `IAsyncCommand` of some kind; either your own (as detailed in my article) or one from a library (e.g., MvvmCross). Here's an example using the MvvmCross types:
C#
public IMvxAsyncCommand TestResultsCommand { get; private set; }
TestResultsCommand = new MvxAsyncCommand(OnTestResultExecuteAsync);
private async Task OnTestResultExecuteAsync() // back to private
{
  TokenSource = new CancellationTokenSource();
  CancellationToken = TokenSource.Token;
  await TestHistoricalResultsAsync();
}
[Fact]
public async Task OnTestResultExecuteAsync_ShouldCreateCancellationTokenSource_True()
{
  CancellationTokenSource tokenSource = new CancellationTokenSource();
  CancellationToken cancellationToken = tokenSource.Token;
  await _viewModel.TestResultsCommand.ExecuteAsync();
  Assert.Equal(cancellationToken.CanBeCanceled, _viewModel.CancellationToken.CanBeCanceled);
  Assert.Equal(cancellationToken.IsCancellationRequested, _viewModel.CancellationToken.IsCancellationRequested);
}
If you prefer the `IMvxAsyncCommand` approach but don't want the MvvmCross dependency, it's not hard to [define your own `IAsyncCommand` and `AsyncCommand` types][2].
  [1]: https://msdn.microsoft.com/en-us/magazine/jj991977.aspx
  [2]: https://msdn.microsoft.com/en-us/magazine/dn630647.aspx
