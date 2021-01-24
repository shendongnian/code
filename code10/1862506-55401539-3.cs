      [OperationBehavior(AutoDisposeParameters = false)]
      Task IStorageBackendSvc.AcceptWmaMediaType(int stationId, OpaqueMediaType mediaType) {
         try {
            WmaWriter wmaWriter = GetWmaWriter(stationId);
            wmaWriter.MediaType = mediaType;
            return Task.CompletedTask;
         } catch( Exception exception ) {
            throw _faultFactory.Wrap(exception);
         }
      }
