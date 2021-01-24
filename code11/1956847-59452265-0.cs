for (var i = 1; i < bestHands.Count; i++)
                        Console.Out.Write(
                                        table.DisplayCards(bestHands[i - 1].Item2.Cards())
                                        + (bestHands[i].Item1 == bestHands[i - 1].Item1 ? "=" : " ")
                                        + (i == bestHands.Count - 1 ? table.DisplayCards(bestHands[i].Item2.Cards()) : ""));
                    if (Console.In.Peek() != -1)  
                        Console.Out.WriteLine();
