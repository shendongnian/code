                                      if (!string.IsNullOrWhiteSpace(caller) && !string.IsNullOrWhiteSpace(now) && !string.IsNullOrWhiteSpace(callee))
                                        {
                                            var recentChannel = activeChannels.FirstOrDefault(c => c.CallerExt == caller && c.CalleeExt == callee);
                                            if (recentChannel != null)
                                                recentChannel.ChannelName = now;
                                        }
