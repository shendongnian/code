        public async Task StartAsync(CancellationToken cancellationToken = default)
        {
            _logger.Starting();
            await _hostLifetime.WaitForStartAsync(cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            _hostedServices = Services.GetService<IEnumerable<IHostedService>>();
            foreach (var hostedService in _hostedServices)
            {
                // Fire IHostedService.Start
                await hostedService.StartAsync(cancellationToken).ConfigureAwait(false);
            }
            // Fire IHostApplicationLifetime.Started
            _applicationLifetime?.NotifyStarted();
            _logger.Started();
        }
