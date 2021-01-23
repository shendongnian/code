    				using (context ctx = new context())
					{
						ctx.AddToParents(parent);
						foreach (foo f in bars)
						{
							parent.Foos.Add(f);
							ctx.AddToFoos(f);
						}
						ctx.SaveChanges();
					}
