	using System;
	using System.Linq;
	using System.Collections.Generic;
	
	public class Program
	{
		public class Section
		{
			public int Id { get; set; } //dont care
			public int SectionID { get; set; } //the actual ID I use
			public int SectionRowId { get; set; } //something else
			public string Name { get; set; } //just display
			public int ParentID { get; set; } //parent id connection
		}
	
		private static Random _R = new Random();
		private static List<Section> sections = new List<Section>();
	
		public static void Main()
		{
			//example good list
			sections = new List<Section>
				{
					 new Section() { Id = 1,    Name = (new Random().Next(1000)).ToString(), SectionID = 888,     SectionRowId = 1, ParentID = 0    }
					,new Section() { Id = 2,    Name = (new Random().Next(1000)).ToString(), SectionID = 137,     SectionRowId = 1, ParentID = 0    }
					,new Section() { Id = 3,    Name = (new Random().Next(1000)).ToString(), SectionID = 137,     SectionRowId = 2, ParentID = 0    }
					,new Section() { Id = 4,    Name = (new Random().Next(1000)).ToString(), SectionID = 137,     SectionRowId = 3, ParentID = 888  }
					,new Section() { Id = 5,    Name = (new Random().Next(1000)).ToString(), SectionID = 137,     SectionRowId = 4, ParentID = 0    }
					,new Section() { Id = 6,    Name = (new Random().Next(1000)).ToString(), SectionID = 3,       SectionRowId = 1, ParentID = 0    }
					,new Section() { Id = 7,    Name = (new Random().Next(1000)).ToString(), SectionID = 3,       SectionRowId = 2, ParentID = 0    }
					,new Section() { Id = 8,    Name = (new Random().Next(1000)).ToString(), SectionID = 3,       SectionRowId = 3, ParentID = 137  }
					,new Section() { Id = 9,    Name = (new Random().Next(1000)).ToString(), SectionID = 900,     SectionRowId = 1, ParentID = 3    }
					,new Section() { Id = 10,   Name = (new Random().Next(1000)).ToString(), SectionID = 11,      SectionRowId = 1, ParentID = 900  }
					,new Section() { Id = 11,   Name = (new Random().Next(1000)).ToString(), SectionID = 8,       SectionRowId = 1, ParentID = 137  }
					,new Section() { Id = 12,   Name = (new Random().Next(1000)).ToString(), SectionID = 8,       SectionRowId = 2, ParentID = 0    }
					,new Section() { Id = 13,   Name = (new Random().Next(1000)).ToString(), SectionID = 777,     SectionRowId = 1, ParentID = 0    }
					,new Section() { Id = 14,   Name = (new Random().Next(1000)).ToString(), SectionID = 777,     SectionRowId = 2, ParentID = 137  }
					,new Section() { Id = 15,   Name = (new Random().Next(1000)).ToString(), SectionID = 777,     SectionRowId = 3, ParentID = 888  }
					,new Section() { Id = 16,   Name = (new Random().Next(1000)).ToString(), SectionID = 777,     SectionRowId = 4, ParentID = 0    }
					,new Section() { Id = 17,   Name = (new Random().Next(1000)).ToString(), SectionID = 777,     SectionRowId = 5, ParentID = 3    }
				};
	
			sections = MixList(sections); //mix the list items
	
			List<Section> sortedList = SortTheList(sections); //sort them
	
			//the bottom part is just for visual
			if (sections != null && sortedList != null)
			{
				if (sections.Count() > 0 && sortedList.Count() > 0)
				{
					if (sections.Count() == sortedList.Count())
					{
	
						string outSortA = "";
						for (int i = 0; i < sections.Count(); i++)
						{
							Section original = sections[i];
							Section sorted = sortedList[i];
							outSortA += Environment.NewLine;
							outSortA += original.Id.ToString("000000") + ") - [ " + original.SectionID.ToString("000000") + " / " + original.SectionRowId.ToString("000000") + " ]";
							if (original.ParentID > 0) { outSortA += " <-- " + original.ParentID.ToString("000000"); } else { outSortA += "           "; }
							outSortA += "    |    ";
							outSortA += sorted.Id.ToString("000000") + ") - [ " + sorted.SectionID.ToString("000000") + " / " + sorted.SectionRowId.ToString("000000") + " ]";
							if (sorted.ParentID > 0) { outSortA += " <-- " + sorted.ParentID.ToString("000000"); }
						}
	
						Console.WriteLine("Items count: " + sections.Count().ToString());
						Console.WriteLine("Final result is: " + FinalTest(sortedList).ToString());
						Console.WriteLine("");
						Console.WriteLine("");
						Console.WriteLine("            [ ORIGINAL LIST ]               |                [ SORTED LIST ]                   ");
						Console.WriteLine("-----------------------------------------------------------------------------------------------");
						Console.WriteLine("  ID    |    Section / Row     |   Parent   |     ID    |    Section / Row     |   Parent      ");
						Console.WriteLine(outSortA);
	
					}
					else
					{
						Console.WriteLine("Final result is: False! (The lists do not match)");
					}
				}
				else
				{
					Console.WriteLine("Final result is: False! (The lists are empty)");
				}
			}
			else
			{
				Console.WriteLine("Final result is: False! (The lists are empty)");
			}
		}
	
		//---------------------------------------------------------------------------------------------------------
		// SORTING FUNCTIONALITY
		//---------------------------------------------------------------------------------------------------------
	
		private static List<Section> SortTheList(List<Section> messyList)
		{
			List<Section> newList = new List<Section>();
			List<Section> outList = new List<Section>();
			newList.AddRange(messyList);
	
			int[] sectionIDs = newList.Select(x => x.SectionID).Distinct().ToArray();
			int[] no = GetOrder(newList).ToArray();
			foreach (int sectionID in no)
			{
				IEnumerable<Section> thisSectionGroup = newList.Where(x => x.SectionID == sectionID);
				thisSectionGroup = thisSectionGroup.OrderBy(x => x.SectionRowId).ThenBy(x => x.ParentID);
				outList.AddRange(thisSectionGroup);
			}
	
			return outList;
		}
	
		private static List<int> GetOrder(List<Section> allSections)
		{
	
			Dictionary<int, int> orderList = new Dictionary<int, int>();
			int[] sectionIDs = allSections.Select(x => x.SectionID).Distinct().ToArray();
			foreach (int sectionID in sectionIDs) { orderList.Add(sectionID, 0); }
			foreach (int sectionID in sectionIDs)
			{
				int[] parentIDs = allSections.Where(x => x.SectionID == sectionID && x.ParentID > 0).Select(x => x.ParentID).ToArray();
				foreach (int parentID in parentIDs)
				{
					IncParents(allSections, parentID, ref orderList);
				}
			}
			return orderList.OrderByDescending(x => x.Value).Select(x => x.Key).ToList();
		}
	
		private static void IncParents(List<Section> allSections, int parentID, ref Dictionary<int, int> orderList, int incLevel = 1)
		{
			orderList[parentID] = orderList[parentID] + incLevel;
			int[] parentIDs = allSections.Where(x => x.SectionID == parentID && x.ParentID > 0).Select(x => x.ParentID).ToArray();
			foreach (int subParentID in parentIDs)
			{
				IncParents(allSections, subParentID, ref orderList, (incLevel + 1));
			}
		}
		//---------------------------------------------------------------------------------------------------------
		//the bottom part is just for visual
		private static List<Section> MixList(List<Section> listOriginal)
		{
			List<Section> rListMessy = new List<Section>();
	
			while (rListMessy.Count() != listOriginal.Count())
			{
				int cID = _R.Next(0, listOriginal.Count());
				if (!rListMessy.Any(x => x.Id == listOriginal[cID].Id))
				{
					rListMessy.Add(listOriginal[cID]);
				}
			}
	
			return rListMessy;
		}
	
		private static bool FinalTest(List<Section> finalList)
		{
	
			if (finalList == null || finalList.Count() == 0) { return false; }
	
			List<Section> finalListAdditions = new List<Section>();
	
			finalListAdditions.Add(new Section() { Id = 10000, Name = "dummy", SectionID = 0, SectionRowId = 0, ParentID = 0 });
	
			int cIndex = 0;
			foreach (Section p in finalList)
			{
				IEnumerable<Section> sCheckParent = finalListAdditions.Where(x => x.SectionID == p.ParentID);
				if (sCheckParent != null)
				{
					int prevIndex = 0;
					foreach (Section parent in sCheckParent)
					{
						int cParentIndex = finalList.IndexOf(parent);
						if (finalList.IndexOf(parent) != prevIndex + 1 && prevIndex != 0)
						{
							return false;
						}
						prevIndex = cParentIndex;
					}
				}
	
				if (sCheckParent.Count() > 0)
				{
					finalListAdditions.Add(p);
				}
				else
				{
					return false;
				}
				cIndex++;
			}
	
			return true;
		}
	}
