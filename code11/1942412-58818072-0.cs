        public void DeleteScrapItem(DeleteScrapItemCommand command)
        {
            using (var scope = new TransactionScope())
            {
                Action<dynamic> updateAssetStatus = p => this.CommandBus.Dispatch(new UpdateAssetStatusCommand()
                {
                    AssetId = p.AssetId,
                    Status = 0
                });
                this.eventBus.Subscribe<ScrapItemRemovedEvent>(updateAssetStatus);
                this.CommandBus.Dispatch(command);
                scope.Complete(); // forgot put this ...
            }
        }
