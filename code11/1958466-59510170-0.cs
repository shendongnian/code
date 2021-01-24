c#
var measureJobId = await _backgroundJobManager.EnqueueAsync<FileProcessBackgroundJob, FileProcessJobArgsDto>(
        new FileProcessJobArgsDto
        {
            Id = Id,
            User = user,
        }
    )
    .ContinueWith(task => _backgroundJobManager.EnqueueAsync<AnalyticsBackgroundJob, AnalyticsJobArgsDto>(
        new AnalyticsJobArgsDto("measureJob")
    )
    .Unwrap();
Compare that to:
c#
var processJobId = await _backgroundJobManager.EnqueueAsync<FileProcessBackgroundJob, FileProcessJobArgsDto>(
        new FileProcessJobArgsDto
        {
            Id = Id,
            User = user,
        }
    );
var measureJobId = await _backgroundJobManager.EnqueueAsync<AnalyticsBackgroundJob, AnalyticsJobArgsDto>(
        new AnalyticsJobArgsDto("measureJob")
    );
