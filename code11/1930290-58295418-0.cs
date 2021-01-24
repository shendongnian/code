//In the setup part
var mockLog = new Mock<ILogger>(MockBehavior.Strict);
string error = null;
mockLog.Setup(l => l
	.Error(It.IsAny<Exception>(), It.IsAny<string>()))
	.Callback((Exception b, string c) =>
	{
		error = c + " " + b.GetBaseException().Message;
        // This would keep only the last error, but it's OK, since there should be zero
        // Sometimes I use a collection and append the error info.
	});
//In the assert part
Assert.IsNull(error, $"Error detected: {error}");
