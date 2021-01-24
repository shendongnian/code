    if (commandLocationMode == CommandLocationMode.PrimaryOnly)
                    {
                        if (restCMD.LocationMode == LocationMode.SecondaryOnly)
                        {
                            throw new InvalidOperationException("This operation can only be executed against the primary storage location.");//This is the error that gets thrown.
                        }
                        Logger.LogInformational(executionState.OperationContext, "This operation can only be executed against the primary storage location.", Array.Empty<object>());
                        executionState.CurrentLocation = StorageLocation.Primary;
                        restCMD.LocationMode = LocationMode.PrimaryOnly;
                    }
