                        if (NodeCache.TryGetValue(x, out node))
                            observer.OnNext(node);
                        else
                            _lazyStorage.Value
                                .Fetch(x)
                                .Subscribe(newNode =>
                                {
                                    NodeCache[x] = node;
                                    observer.OnNext(node);
                                });
