				static void RunTryFinallyTest()
				{
					int cnt = 10000000;
					Console.WriteLine(TryFinallyBenchmarker(cnt, false));
					Console.WriteLine(TryFinallyBenchmarker(cnt, false));
					Console.WriteLine(TryFinallyBenchmarker(cnt, false));
					Console.WriteLine(TryFinallyBenchmarker(cnt, false));
					Console.WriteLine(TryFinallyBenchmarker(cnt, false));
					Console.WriteLine(TryFinallyBenchmarker(cnt, true));
					Console.WriteLine(TryFinallyBenchmarker(cnt, true));
					Console.WriteLine(TryFinallyBenchmarker(cnt, true));
					Console.WriteLine(TryFinallyBenchmarker(cnt, true));
					Console.WriteLine(TryFinallyBenchmarker(cnt, true));
					Console.ReadKey();
				}
				static double TryFinallyBenchmarker(int count, bool useTryFinally)
				{
					int over1 = count + 1;
					int over2 = count + 2;
					if (!useTryFinally)
					{
						var sw = Stopwatch.StartNew();
						for (int i = 0; i < count; i++)
						{
							// do something so optimization doesn't ignore whole loop. 
							if (i == over1) throw new Exception();
							if (i == over2) throw new Exception();
						}
						return sw.Elapsed.TotalMilliseconds;
					}
					else
					{
						var sw = Stopwatch.StartNew();
						for (int i = 0; i < count; i++)
						{
							// do same things, just second in the finally, make sure finally is 
							// actually doing something and not optimized out
							try
							{
								if (i == over1) throw new Exception();
							} finally
							{
								if (i == over2) throw new Exception();
							}
						}
						return sw.Elapsed.TotalMilliseconds;
					}
				}
