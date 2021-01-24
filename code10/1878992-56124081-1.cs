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
