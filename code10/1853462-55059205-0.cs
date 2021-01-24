     /// <summary>
            /// Gets a particular session object identified by <paramref name="sessionId"/> that can be used to receive messages for that sessionId.
            /// </summary>
            /// <param name="sessionId">The sessionId present in all its messages.</param>
            /// <param name="operationTimeout">Amount of time for which the call should wait to fetch the next session.</param>
            /// <remarks>All plugins registered on <see cref="SessionClient"/> will be applied to each <see cref="MessageSession"/> that is accepted.
            /// Individual sessions can further register additional plugins.</remarks>
            public async Task<IMessageSession> AcceptMessageSessionAsync(string sessionId, TimeSpan operationTimeout)
            {
                this.ThrowIfClosed();
                MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStart(
                    this.ClientId,
                    this.EntityPath,
                    this.ReceiveMode,
                    this.PrefetchCount,
                    sessionId);
                bool isDiagnosticSourceEnabled = ServiceBusDiagnosticSource.IsEnabled();
                Activity activity = isDiagnosticSourceEnabled ? this.diagnosticSource.AcceptMessageSessionStart(sessionId) : null;
                Task acceptMessageSessionTask = null;
                var session = new MessageSession(
                    this.EntityPath,
                    this.EntityType,
                    this.ReceiveMode,
                    this.ServiceBusConnection,
                    this.CbsTokenProvider,
                    this.RetryPolicy,
                    this.PrefetchCount,
                    sessionId,
                    true);
                try
                {
                    acceptMessageSessionTask = this.RetryPolicy.RunOperation(
                        () => session.GetSessionReceiverLinkAsync(operationTimeout),
                        operationTimeout);
                    await acceptMessageSessionTask.ConfigureAwait(false);
                }
                catch (Exception exception)
                {
                    if (isDiagnosticSourceEnabled)
                    {
                        this.diagnosticSource.ReportException(exception);
                    }
                    MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionException(
                        this.ClientId,
                        this.EntityPath,
                        exception);
                    await session.CloseAsync().ConfigureAwait(false);
                    throw AmqpExceptionHelper.GetClientException(exception);
                }
                finally
                {
                    this.diagnosticSource.AcceptMessageSessionStop(activity, session.SessionId, acceptMessageSessionTask?.Status);
                }
                MessagingEventSource.Log.AmqpSessionClientAcceptMessageSessionStop(
                    this.ClientId,
                    this.EntityPath,
                    session.SessionIdInternal);
                session.UpdateClientId(ClientEntity.GenerateClientId(nameof(MessageSession), $"{this.EntityPath}_{session.SessionId}"));
                // Register plugins on the message session.
                foreach (var serviceBusPlugin in this.RegisteredPlugins)
                {
                    session.RegisterPlugin(serviceBusPlugin);
                }
                return session;
            }
