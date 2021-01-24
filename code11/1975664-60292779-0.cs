		var results = StudentsList.GroupBy(x => x.GroupID)
			                      .Where(g => !g.Any(p => p.Student == "Adam") && g.Any(x => x.University == "OPQ"))
								  .SelectMany(g => 
										{
											var firstItem = g.First(x => x.University == "OPQ");
											firstItem.IsQualified = true;
											
                                            var otherItems = g.Where(x => x.University != "OPQ" && x.Course == "HR")
															  .Select(z => 
																	  {
																		  var item = z;
																		  item.IsQualified = true;
																		  return item;
																	  }).ToList();
											otherItems.Add(firstItem);
											return otherItems;
										}).ToList();
