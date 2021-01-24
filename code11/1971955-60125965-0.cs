csharp
	var list1 = new List<int> { 5, 6 };
	var list2 = new List<UniversityGroup> {
		new UniversityGroup{ UniversityGroupId = 1 ,UniversityId = 6 },
		new UniversityGroup{ UniversityGroupId = 1, UniversityId = 5 },
		new UniversityGroup{ UniversityGroupId = 2, UniversityId = 5 },
	 	new UniversityGroup{ UniversityGroupId = 3, UniversityId = 2 },
		new UniversityGroup{ UniversityGroupId = 3, UniversityId = 3 }
	};
	list1.Sort(); // depending on your input data you might want to apply some ordering so you could match sequences 6,5 to 5,6
	var result = list2.GroupBy(g => g.UniversityGroupId)
					.Where(g => g.Select(i => i.UniversityId)
								.OrderBy(x => x) // this might be optional if you can guarantee source sequence order
								.SequenceEqual(list1)) // here's the thing
					//.Select(g => g.Key) // if you want just UniversityGroupId
                 ;
It is however hard to say whether this query is going to be any better than your couple of *foreach* loops without seing those.
  [1]: https://docs.microsoft.com/en-us/dotnet/api/system.linq.enumerable.sequenceequal?view=netframework-4.8
