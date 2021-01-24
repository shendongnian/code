    public ICollection<ConnectionHandler> GetConnectedClients(long tableId)
      => _gameTableEntries.Where(x => x.TableId == tableId)
                          .SelectMany(x => x.ConnectedClients)
                          .Where(x => x.IsConnected)
                          .ToHashSet();
